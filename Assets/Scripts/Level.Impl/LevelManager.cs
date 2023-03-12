using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour, LevelManagerIfc {

    #region LevelManagerIfc Members

    public bool IsBlockStateOn {
        get;
        private set;
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

        if (closestPlayer == null) {
            return Vector2.zero;
        }
        else {
            return closestPlayer.Position;
        }
    }

    public void PlaceBlock(Vector2 position, Tile tile) {
        Vector3Int cell = m_environment.WorldToCell(position);
        m_environment.SetTile(cell, tile);
    }

    //public void SetBlockState(bool setOn) {
    //    throw new System.NotImplementedException();
    //}

    //public void ToggleBlockState() {
    //    throw new System.NotImplementedException();
    //}

    public bool TryExplode(Vector2 position) {
        Vector3Int cell = m_environment.WorldToCell(position);
        EnvironmentTileIfc tileToExplode = GetTile((Vector2Int)cell);
        if (tileToExplode != null) {
            m_environment.SetTile(cell, tileToExplode.Explode());
            return tileToExplode.IsExplosionStopper;
        }
        else {
            return false;
        }
    }

    //public void TryPlaceItem(Vector2 position) {
    //    throw new System.NotImplementedException();
    //}
    public void PlaceObject(GameObject item, Vector2 position) {
        throw new NotImplementedException();
    }

    //public UnityEvent<Vector2Int> TryPlaceBomb(BombIfc bomb, Vector2Int position) {
    //    UnityEvent<Vector2Int> destroyedEvent = m_bombManager.CreateBomb(bomb.Properties, position);
    //    if (destroyedEvent != null) {
    //        m_explosionManager.
    //    }
    //    return destroyedEvent;
    //}

    public bool IsBetweenBlocks(Vector2 position) {
        return IsBetweenHorizontalCells(position) || IsBetweenVerticalCells(position);
    }

    public Component GetManager<T>() {
        return GetComponentInChildren(typeof(T));
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
        m_bombManager = GetComponentInChildren<BombManagerIfc>();
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
    private BombManagerIfc m_bombManager;
    private ExplosionManagerIfc m_explosionManager;
    private static readonly Vector2Int[] possibleDirections = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    #endregion
}
