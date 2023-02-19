using UnityEngine;

[CreateAssetMenu(fileName = "MonsterType", menuName = "Monsters/MonsterType")]
public class MonsterType : ScriptableObject {

    #region Public Properties

    public int Speed {
        get {
            return (int)m_speed;
        }
    }

    #endregion

    #region Public Methods

    public virtual Vector2Int GetDirection(EntityAbs monster, LevelManagerIfc levelManager) {
        // todo:
        return m_movement.GetDirection(monster, levelManager);
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
    protected MonsterSpeed m_speed;

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
