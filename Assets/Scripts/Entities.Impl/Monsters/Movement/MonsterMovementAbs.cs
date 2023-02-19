using UnityEngine;

/// <summary>
/// Todo:
/// </summary>
public abstract class MonsterMovementAbs : ScriptableObject {

    #region Public Methods

    public abstract Vector2Int GetDirection(EntityAbs monster, LevelManagerIfc levelManager);

    #endregion

}