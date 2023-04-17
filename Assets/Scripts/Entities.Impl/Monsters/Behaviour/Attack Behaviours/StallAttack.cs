public class StallAttack : AttackBehaviourAbs {

    #region MonsterBehaviorAbs Members

    public override void Attack(PlayerIfc player) {
        player.SetStuck();
    }

    #endregion
}