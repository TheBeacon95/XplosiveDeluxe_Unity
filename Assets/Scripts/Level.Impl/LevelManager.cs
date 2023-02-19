using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour, LevelManagerIfc {

    #region Public Properties

    public static LevelManager Instance {
        get {
            return s_instance;
        }
    }

    #endregion

    #region LevelManagerIfc Members

    public bool IsBlockStateOn {
        get;
        private set;
    }

    //Tile tileToDestroy = m_environment.GetTile<Tile>(tilePosition);
    public void DestroyTile(Vector2 position, float time_s = 0) {
        Vector3Int tilePosition = m_environment.WorldToCell(position);
        m_environment.SetTile(tilePosition, null);
    }


    public IList<Vector2Int> GetAvailableDirections(Vector2Int position, bool isBrickMuncher = false) {
        List<Vector2Int> availableDirections = new List<Vector2Int>();
        foreach (Vector2Int direction in possibleDirections) {
            EnvironmentTileAbs nextTile = GetTile(position + direction);
            if (nextTile == null || nextTile.IsWalkable(false)) {
                availableDirections.Add(direction);
            }
        }
        return availableDirections;
    }

    public Vector2Int GetWalkableDirection(Vector2 position, Vector2 desiredDirection, bool isGhost) {
        bool isTryingToMoveHorizontally = desiredDirection.y == 0;
        bool isTryingToMoveVertically = desiredDirection.x == 0;
        bool isBetweenHorizontalCells = IsBetweenHorizontalCells(position);
        bool isBetweenVerticalCells = IsBetweenVerticalCells(position);

        Vector2Int direction = desiredDirection.Floor();

        // If the player is between horizontal cells and trying to move horizontally, they may always move. (and vice versa)
        if ((isTryingToMoveHorizontally && isBetweenHorizontalCells) || (isTryingToMoveVertically && isBetweenVerticalCells)) {
            return direction;
        }
        // If the player is horizontal cells and trying to move perpendicularly to them, move them into the direction of the free cell if there is one.
        else if ((isTryingToMoveHorizontally && isBetweenVerticalCells) || (isTryingToMoveVertically && isBetweenHorizontalCells)) {
            EnvironmentTileAbs floorCell = GetTile(position.Floor() + direction);
            EnvironmentTileAbs ceilCell = GetTile(position.Ceiling() + direction);
            return GetFreeDirection(floorCell, ceilCell, position, isGhost);
        }
        // If the player is not between cells, move them in the desired direction, if its free.
        else if (!isBetweenHorizontalCells && !isBetweenVerticalCells) {
            EnvironmentTileAbs nextTile = GetTile(position.Ceiling() + direction);
            if (nextTile == null) {
                return direction;
            }
            else {
                return nextTile.IsWalkable(isGhost) ? direction : Vector2Int.zero;
            }
        }
        // Unexpected case: The direction is neither horizontal nor vertical.
        else {
            // Todo: "Assert go"
            return Vector2Int.zero;
        }
    }

    public bool IsBombPlaceable(Vector2Int position) {
        Vector3Int cell = m_environment.WorldToCell(new Vector3(position.x, position.y));

        bool isOnGrid = IsGrid(cell);
        bool isBombThere = m_bombManager.IsBombHere(position); // Todo: Implement BombManager
        bool isBombForbidden = false; // Todo: Decide wether there are places where bombs aren't allowed.

        return !isOnGrid && !isBombThere && !isBombForbidden;
    }

    public Vector2 GetNearestPlayer(Vector2 position) {
        PlayerIfc closestPlayer = null;
        float shortestDistance = float.MaxValue;
        foreach (PlayerIfc player in transform.GetComponentsInChildren<PlayerIfc>()) {
            if (closestPlayer == null) {
                closestPlayer = player;
            }
            else {
                float distance = (position - player.Position).magnitude;
                if (distance < shortestDistance) {
                    closestPlayer = player;
                    shortestDistance = distance;
                }
                else if (distance == shortestDistance && (UnityEngine.Random.value * 2) % 2 == 0) {
                    closestPlayer = player;
                }
            }
        }
        return closestPlayer.Position;
    }

    public void PlaceBlock(Vector2 position) {
        throw new System.NotImplementedException();
    }

    //public void SetBlockState(bool setOn) {
    //    throw new System.NotImplementedException();
    //}

    //public void ToggleBlockState() {
    //    throw new System.NotImplementedException();
    //}

    public bool TryExplode(Vector2 position) {
        throw new System.NotImplementedException();
    }

    //public void TryPlaceItem(Vector2 position) {
    //    throw new System.NotImplementedException();
    //}
    public void PlaceObject(GameObject item, Vector2 position) {
        throw new NotImplementedException();
    }

    public UnityEvent<Vector2Int> TryPlaceBomb(BombProperties properties, Vector2Int position) {
        return m_bombManager.CreateBomb(properties, position, this);
    }

    public bool IsBetweenBlocks(Vector2 position) {
        return IsBetweenHorizontalCells(position) || IsBetweenVerticalCells(position);
    }

    #endregion

    #region Private Methods

    private Vector2Int GetFreeDirection(EnvironmentTileAbs floorCell, EnvironmentTileAbs ceilCell, Vector2 position, bool isGhost) {
        bool isFloorCellWalkable = floorCell != null ? floorCell.IsWalkable(isGhost) : true;
        bool isCeilCellWalkable = ceilCell != null ? ceilCell.IsWalkable(isGhost) : true;

        Vector2 direction = Vector2.zero;
        if (isFloorCellWalkable) {
            direction = position.Floor() - position;
        }
        else if (isCeilCellWalkable) {
            direction = position.Ceiling() - position;
        }
        else {
            return Vector2Int.zero;
        }

        // If the direction is negative it needs to be rounded down. Otherwise the vector will be (0,0).
        if (direction.x < 0 || direction.y < 0) {
            return direction.Floor();
        }
        else {
            return direction.Ceiling();
        }
    }

    // Todo: finish implementing
    private bool IsGrid(Vector3Int cell) {
        Vector3Int size = m_environment.size;
        Vector3Int origin = m_environment.origin;

        int xBounds = origin.x + (int)(size.x / 2f);
        int yBounds = origin.y + (int)(size.y / 2f);

        return false;
    }

    private EnvironmentTileAbs GetTile(Vector2Int position) {
        EnvironmentTileAbs tile = null;
        if (m_bombManager.IsBombHere(position)) {
            tile = Resources.Load<EnvironmentTileAbs>("Tiles/BombTile");
        }
        else {
            tile = m_environment.GetTile<EnvironmentTileAbs>(m_environment.WorldToCell((Vector3Int)(position)));
        }
        return tile;
    }

    private void Awake() {
        if (s_instance != null) {
            Destroy(gameObject);
        }
        else {
            s_instance = this;
            m_bombManager = gameObject.AddComponent<BombManager>();
        }
    }

    private bool IsBetweenHorizontalCells(Vector2 position) {
        return Math.Round(position.x) != position.x;
    }

    private bool IsBetweenVerticalCells(Vector2 position) {
        return Math.Round(position.y) != position.y;
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private Tilemap m_environment;
    private BombManager m_bombManager;
    private static LevelManager s_instance;
    private static readonly Vector2Int[] possibleDirections = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    #endregion
}
