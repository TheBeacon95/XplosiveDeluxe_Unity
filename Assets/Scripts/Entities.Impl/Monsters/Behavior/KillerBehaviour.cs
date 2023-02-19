using UnityEngine;

[CreateAssetMenu(fileName = "KillerBehaviour", menuName = "Monsters/Behaviours/Killer")]
public class KillerBehaviour : MonsterBehaviourAbs {

    #region MonsterBehaviourAbs Members

    public override void Attack(MonoBehaviour monster, PlayerIfc player) {
        // Todo: implement
    }

    public override void Collect(MonoBehaviour monster, CollectableIfc collectable) {
        // Todo: implement
    }

    public override void Explode(MonoBehaviour monster, ExplosionIfc explosion) {
        // Todo: implement
    }

    #endregion

}