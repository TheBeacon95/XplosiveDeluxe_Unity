using UnityEngine;

/// <summary>
/// Holds all the attributes of a monster.
/// Todo: describe that way better
/// </summary>
[CreateAssetMenu(fileName = "Monster Behaviour", menuName = "Monsters/Behaviours/Empty")]
public class MonsterBehaviour : ScriptableObject {

    #region Public Methods

    public void Attack(PlayerIfc player) {
        if (m_attackBehaviour != null) {
            m_attackBehaviour.Attack(player);
        }
    }

    public void Collect(CollectableIfc collectable) {
        if (m_collectBehaviour != null) {
            m_collectBehaviour.Collect(collectable);
        }
    }

    public void Explode(MonoBehaviour monster, ExplosionIfc explosion) {
        if (m_explodeBehaviour != null) {
            m_explodeBehaviour.Explode(monster, explosion);
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private AttackBehaviourAbs m_attackBehaviour;

    [SerializeField]
    private CollectBehaviourAbs m_collectBehaviour;

    [SerializeField]
    private ExplosionBehaviourAbs m_explodeBehaviour;

    #endregion
}