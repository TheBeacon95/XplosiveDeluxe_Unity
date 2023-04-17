using System;
using UnityEngine;

public abstract class SpecialBehaviourAbs : ScriptableObject {

    /// <summary>
    /// Starts the coroutines that handle Stalling.
    /// </summary>
    /// <param name="monster">The MonsterController that holds this asset.</param>
    /// <param name="levelManager"></param>
    public virtual void Init(MonsterController monster, LevelManagerIfc levelManager) {
        // Do nothing.
    }

    public virtual void LateInit(MonsterController monster, LevelManagerIfc levelManager) {
        // Do nothing.
    }

    public virtual void Stop(MonsterController monster, bool force) {
        // Do nothing.
    }
}