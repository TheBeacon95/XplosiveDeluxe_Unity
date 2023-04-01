using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

[CreateAssetMenu(fileName = "StallOnBrickEat", menuName = "Monsters/Behaviours/Special Behaviours/StallOnBrickEat")]
public class StallOnBrickEat : SpecialBehaviourAbs {

    #region SpecialBehvaviour Members

    public override void Init(MonsterController monster, LevelManagerIfc levelManager) {
        //Todo: implement: coroutine that checks if the monster just ate a brick.
        monster.StartCoroutine(EatBricks(monster, levelManager));
    }

    #endregion

    #region Private Methods

    // Todo: This method waits in a weird way. Rewrite this. Maybe check in a different way if theres an eatable block
    // e.g: Wait for a random amount of time and then check or have the MonsterController fire an event whenever IsBetweenBlocks is true.
    // However, make sure, that the eater can always escape if he's trapped between blocks.
    private IEnumerator EatBricks(MonsterController monster, LevelManagerIfc levelManager) {
        while (true) {
            if (!monster.IsIdle || levelManager.IsBetweenBlocks(monster.Position)) {
                yield return null;
                continue;
            }

            List<Vector2Int> brickDirections = levelManager.GetEatableBricks(monster.Position.Round());
            if (brickDirections.Count <= 0) {
                yield return null;
                continue;
            }

            int chosenDirection = UnityRandom.Range(0, brickDirections.Count * 2);
            if (chosenDirection >= brickDirections.Count) {
                yield return null;
                continue;
            }
            else {
                monster.DoMove(brickDirections[chosenDirection]);
            }
        }
    }

    #endregion

}