using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour, LevelManagerIfc {
    private Tilemap m_environment;


    #region LevelManagerIfc Members

    public BlockState BlockState {
        get;
        private set;
    }

    //Tile tileToDestroy = m_environment.GetTile<Tile>(tilePosition);
    public void DestroyTile(Vector2 position, float time_s = 0) {
        Vector3Int tilePosition = m_environment.WorldToCell(position);
        m_environment.SetTile(tilePosition, null);
    }


    public IList<Vector2> GetAvailableDirections(Vector2 position, bool isBrickMuncher = false) {
        throw new System.NotImplementedException();
    }

    public Vector2Int GetWalkableDirection(Vector2 position, Vector2 desiredDirection, bool isGhost) {
        bool isTryingToMoveHorizontally = desiredDirection.y == 0;
        bool isTryingToMoveVertically = desiredDirection.x == 0;
        bool isBetweenHorizontalCells = Math.Round(position.x) != position.x;
        bool isBetweenVerticalCells = Math.Round(position.y) != position.y;

        Vector2Int direction = desiredDirection.Floor();

        // If the player is between horizontal cells and trying to move horizontally, they may always move. (and vice versa)
        if ((isTryingToMoveHorizontally && isBetweenHorizontalCells) || (isTryingToMoveVertically && isBetweenVerticalCells)) {
            return direction;
        }
        // If the player is horizontal cells and trying to move perpendicularly to them, move them into the direction of the free cell if there is one.
        else if ((isTryingToMoveHorizontally && isBetweenVerticalCells) || (isTryingToMoveVertically && isBetweenHorizontalCells)) {
            EnvironmentTileAbs floorCell = m_environment.GetTile<EnvironmentTileAbs>((Vector3Int)(position.Floor() + direction));
            EnvironmentTileAbs ceilCell = m_environment.GetTile<EnvironmentTileAbs>((Vector3Int)(position.Ceiling() + direction));
            return GetFreeDirection(floorCell, ceilCell, direction, isGhost);
        }
        // If the player is not between cells, move them in the desired direction, if its free.
        else if (!isBetweenHorizontalCells && !isBetweenVerticalCells) {
            return m_environment.GetTile<EnvironmentTileAbs>((Vector3Int)(position.Ceiling() + direction)).IsWalkable(isGhost) ? direction : Vector2Int.zero;
        }
        // Unexpected case: The direction is neither horizontal nor vertical.
        else {
            // Todo: "Assert go"
            return Vector2Int.zero;
        }
    }

    public Vector2 GetMovableDirection(Vector2 position, Vector2 direction) {
        throw new System.NotImplementedException();
    }

    public Vector2 GetNearestPlayer(Vector2 position) {
        throw new System.NotImplementedException();
    }

    public void PlaceBlock(Vector2 position) {
        throw new System.NotImplementedException();
    }

    public void PlaceItem(GameObject item, Vector2 position) {
        throw new System.NotImplementedException();
    }

    public void SetBlockState(bool setOn) {
        throw new System.NotImplementedException();
    }

    public void ToggleBlockState() {
        throw new System.NotImplementedException();
    }

    public bool TryExplode(Vector2 position) {
        throw new System.NotImplementedException();
    }

    public void TryPlaceItem(Vector2 position) {
        throw new System.NotImplementedException();
    }


    #endregion

    #region Private Methods

    private Vector2Int GetFreeDirection(EnvironmentTileAbs floorCell, EnvironmentTileAbs ceilCell, Vector2 position, bool isGhost) {
        bool isFloorCellWalkable = floorCell != null ? floorCell.IsWalkable(isGhost) : true;
        bool isCeilCellWalkable = ceilCell != null ? ceilCell.IsWalkable(isGhost) : true;

        if (isFloorCellWalkable) {
            return (position.Floor() - position).Ceiling();
        }
        else if (isCeilCellWalkable) {
            return (position.Ceiling() - position).Ceiling();
        }
        else {
            return Vector2Int.zero;
        }
    }

    #endregion
}
