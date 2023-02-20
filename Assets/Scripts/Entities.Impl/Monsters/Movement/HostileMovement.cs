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
            return GetBestDirection(monster.Position.Round(), monster.Direction, levelManager);
        }
    }

    private Vector2Int GetBestDirection(Vector2Int position, Vector2Int currentDirection, LevelManagerIfc levelManager) {
        IList<Vector2Int> possibleDirections = levelManager.GetAvailableDirections(position);
        RemoveUnusablePaths(possibleDirections, currentDirection);
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

    /// <Summary>
    /// Monsters that use hostile movement cannot turn around, unless there's no other path to take.
    /// This method removes the opposite direction if others are available.
    /// <Summary>
    /// todo: param
    private void RemoveUnusablePaths(IList<Vector2Int> availablePaths, Vector2Int currentDirection) {
        // There is no reason to remove a path if there are either one ore no paths at all, since the monster will either not move at all or turn around.
        if (availablePaths.Count > 1) {
            Vector2Int oppositeDirection = currentDirection * (-1);
            if (availablePaths.Contains(oppositeDirection)) {
                availablePaths.Remove(oppositeDirection);
            }
        }
    }
}