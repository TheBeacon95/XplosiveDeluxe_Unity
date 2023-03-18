using UnityEngine;

public abstract class CollectBehaviourAbs : ScriptableObject {

    #region Public Methods

    public abstract void Collect(CollectableIfc collectable);

    #endregion

}