using UnityEngine.Tilemaps;
/// <summary>
///
/// </summary>
public interface EnvironmentTileIfc {

    #region Methods

    /// <summary>
    /// Shows whether an entity can walk over it.
    /// </summary>
    /// <param name="isGhost"></param>
    /// <returns></returns>
    bool IsWalkable(bool isGhost);

    /// <summary>
    /// IsCalled when an explosion hits it.
    /// </summary>
    Tile Explode();

    #endregion

    #region Properties

    /// <summary>
    /// Shows whether an Explosion can continue or not.
    /// </summary>
    bool IsExplosionStopper {
        get;
    }

    #endregion
}