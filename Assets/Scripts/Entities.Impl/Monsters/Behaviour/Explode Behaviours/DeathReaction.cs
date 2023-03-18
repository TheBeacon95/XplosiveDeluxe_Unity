using UnityEngine;

[CreateAssetMenu(fileName = "DeathReaction", menuName = "Monsters/Behaviours/Explosion Reactions/Death")]
public class DeathReaction : ExplosionBehaviourAbs {

    #region ExplosionBehaviourAbs Members

    public override void Explode(MonoBehaviour monster, ExplosionIfc explosion) {
        Destroy(monster.gameObject);
    }

    #endregion

}