using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds all the attributes of a monster.
/// Todo: describe that way better
/// </summary>
public abstract class MonsterBehaviourAbs : ScriptableObject {

	#region Public Methods

	public abstract void Attack(MonoBehaviour monster, PlayerIfc player);

	public abstract void Collect(MonoBehaviour monster, CollectableIfc collectable);

	public abstract void Explode(MonoBehaviour monster, ExplosionIfc explosion);

	#endregion

}