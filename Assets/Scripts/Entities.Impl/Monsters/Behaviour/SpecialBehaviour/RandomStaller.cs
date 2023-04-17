using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomStaller", menuName = "Monsters/Behaviours/Special Behaviours/Random Staller")]
public class RandomStaller : SpecialBehaviourAbs {
    public override void LateInit(MonsterController monster, LevelManagerIfc levelManager) {
        monster.StartCoroutine(StallerCoroutine(monster));
    }

    public override void Stop(MonsterController monster, bool force) {
        monster.StopCoroutine("StallerCoroutine");
    }

    private IEnumerator StallerCoroutine(MonsterController monster) {
        while (true) {
            if (monster.IsStalled) {
                yield return WAIT_FOR_EFFECT_TIMER; // Todo improve: Make the stalling independent from this Wait Timer
            }
            else {
                YieldInstruction activeWaitInstruction = s_activeWaitInstructions[Random.Range(0, s_activeWaitInstructions.Count)];
                YieldInstruction stallWaitInstruction = s_stallWaitInstructions[Random.Range(0, s_stallWaitInstructions.Count)];

                yield return activeWaitInstruction;
                monster.IsStalled = true;

                yield return stallWaitInstruction;
                monster.IsStalled = false;
            }
        }
    }

    private static readonly IReadOnlyList<YieldInstruction> s_activeWaitInstructions = new List<YieldInstruction>() {
        new WaitForSeconds(2.5f),
        new WaitForSeconds(3f),
        new WaitForSeconds(3.5f),
        new WaitForSeconds(4f),
        new WaitForSeconds(4.5f),
        new WaitForSeconds(5f),
        new WaitForSeconds(5.5f),
        new WaitForSeconds(6f)
    };

    private static readonly IReadOnlyList<YieldInstruction> s_stallWaitInstructions = new List<YieldInstruction>() {
        new WaitForSeconds(0.5f),
        new WaitForSeconds(1f),
        new WaitForSeconds(1.5f),
        new WaitForSeconds(2f),
        new WaitForSeconds(2.5f),
        new WaitForSeconds(3f),
        new WaitForSeconds(3.5f),
        new WaitForSeconds(4f)
    };

    private static readonly YieldInstruction WAIT_FOR_EFFECT_TIMER = new WaitForSeconds(1f);
}