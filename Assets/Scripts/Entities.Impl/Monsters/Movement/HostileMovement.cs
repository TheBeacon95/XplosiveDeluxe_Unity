using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HostileMovement", menuName = "Monsters/Movement/Hostile")]
public class HostileMovement : MonsterMovementAbs {

    #region MonsterMovementAbs Members

    #endregion
    public override Vector2Int GetDirection(EntityAbs monster, LevelManagerIfc levelManager) {
        Vector2Int direction = monster.Direction;
        if (levelManager.IsBetweenBlocks(monster.Position)) {
            // Follow path
            return direction;
        }
        //Todo: Monsters shouldn't be able to turn back.
        else {
            return GetBestDirection(monster.Position.Round(), levelManager);
        }
    }

    private Vector2Int GetBestDirection(Vector2Int position, LevelManagerIfc levelManager) {
        IList<Vector2Int> possibleDirections = levelManager.GetAvailableDirections(position);
        Vector2 nearestPlayer = levelManager.GetNearestPlayer(position);
        float shortestDistanceToPlayer = float.MaxValue;
        Vector2Int bestDirection = Vector2Int.zero;
        foreach (Vector2Int direction in possibleDirections) {
            float distance = (position + direction - nearestPlayer).magnitude;
            if (distance < shortestDistanceToPlayer) {
                shortestDistanceToPlayer = distance;
                bestDirection = direction;
            }
            else if (distance == shortestDistanceToPlayer) {
                if ((int)(Random.value * 2) % 2 == 0) {
                    bestDirection = direction;
                }
            }
        }
        return bestDirection;
    }
}