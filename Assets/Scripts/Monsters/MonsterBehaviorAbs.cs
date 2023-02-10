using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds all the attributes of a monster.
/// Todo: describe that way better
/// </summary>
public abstract class MonsterBehaviorAbs : ScriptableObject {

    #region Private Fields

    [SerializeField]
    private MonsterMovementAbs m_movementType;

    [SerializeField]
    private List<Sprite> m_sprites;

    #endregion
}