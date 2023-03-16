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
        foreach (SpecialBehaviour specialBehaviour in m_specialBehaviours) {
            specialBehaviour.Init(monster, levelManager);
        }
    }

    public bool IsConfiguredProperly() {
        // Todo: Consider ProperlyConfiguredIfc (with better naming)
        return true;
    }

    #endregion

    #region Protected Fields

    [SerializeField]
    protected MonsterMovementAbs m_movement;

    [SerializeField]
    protected MonsterBehaviourAbs m_behavior;

    [SerializeField]
    protected SpriteHandlerAbs m_spriteHandler;

    [SerializeField]
    protected List<SpecialBehaviour> m_specialBehaviours;

    [SerializeField]
    protected EntitySpeed m_speed;

    #endregion

    #region Private Methods

    public void Attack(MonoBehaviour monster, PlayerIfc player) {
        m_behavior.Attack(monster, player);
    }

    public void Collect(MonoBehaviour monster, CollectableIfc collectable) {
        m_behavior.Collect(monster, collectable);
    }

    public void Explode(MonoBehaviour monster, ExplosionIfc explosion) {
        m_behavior.Explode(monster, explosion);
    }

    #endregion
}
