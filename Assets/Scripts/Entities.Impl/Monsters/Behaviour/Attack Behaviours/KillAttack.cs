using UnityEngine;

[CreateAssetMenu(fileName = "Kill Attack", menuName = "Monsters/Behaviours/Attacks/Kill")]
public class KillAttack : AttackBehaviourAbs {

    #region MonsterBehaviourAbs Members

    public override void Attack(PlayerIfc player) {
        player.Kill();
    }

    #endregion

}