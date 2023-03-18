using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExplosionBehaviourAbs : ScriptableObject {

    #region Public Methods

    public abstract void Explode(MonoBehaviour monster, ExplosionIfc explosion);

    #endregion

}