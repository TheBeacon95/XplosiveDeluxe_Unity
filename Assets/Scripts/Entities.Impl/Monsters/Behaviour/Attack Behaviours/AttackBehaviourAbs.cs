using UnityEngine;

public abstract class AttackBehaviourAbs : ScriptableObject {

    #region Public Methods

    public abstract void Attack(PlayerIfc player);

    #endregion
}
