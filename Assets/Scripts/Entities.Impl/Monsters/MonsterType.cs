using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterType", menuName = "Monsters/MonsterType")]
public class MonsterType : ScriptableObject {

    #region Public Properties

    public int Speed {
        get {
            return (int)m_speed;
        }
    }

    public SpriteHandlerAbs SpriteHandler {
        get {
            return m_spriteHandler;
        }
    }

    #endregion

    #region Public Methods

    public virtual Vector2Int GetDirection(EntityAbs monster, LevelManagerIfc levelManager) {
        return m_movement.GetDirection(monster, levelManager);
    }

    public void Init(MonsterController monster, LevelManagerIfc levelManager) {
        foreach (SpecialBehaviourAbs specialBehaviour in m_specialBehaviours) {
            specialBehaviour.Init(monster, levelManager);
        }
        LateInit(monster, levelManager);
    }

    public void LateInit(MonsterController monster, LevelManagerIfc levelManager) {
        foreach (SpecialBehaviourAbs specialBehaviour in m_specialBehaviours) {
            specialBehaviour.LateInit(monster, levelManager);
        }
    }

    public void Stop(MonsterController monster, bool force) {
        foreach (SpecialBehaviourAbs specialBehaviour in m_specialBehaviours) {
            specialBehaviour.Stop(monster, force);
        }
    }

    public bool IsConfiguredProperly() {
        // Todo: Consider ProperlyConfiguredIfc (with better naming)
        return true;
    }

    public void Attack(PlayerIfc player) {
        m_behavior.Attack(player);
    }

    public void Collect(CollectableIfc collectable) {
        m_behavior.Collect(collectable);
    }

    public void Explode(MonoBehaviour monster, ExplosionIfc explosion) {
        m_behavior.Explode(monster, explosion);
    }

    #endregion

    #region Protected Fields

    [SerializeField]
    protected MonsterMovementAbs m_movement;

    [SerializeField]
    protected MonsterBehaviour m_behavior;

    [SerializeField]
    protected SpriteHandlerAbs m_spriteHandler;

    [SerializeField]
    protected List<SpecialBehaviourAbs> m_specialBehaviours;

    [SerializeField]
    protected EntitySpeed m_speed;

    #endregion
}
