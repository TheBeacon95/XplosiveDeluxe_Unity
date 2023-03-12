using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class EnvironmentTileAbs : Tile, EnvironmentTileIfc {

    #region EnvironmentTileIfc Members

    // Usually blocks stop explosions. Override if a blocktype can let explosions continue.
    public virtual bool IsExplosionStopper {
        get {
            return true;
        }
    }

    public Tile Explode() {
        // Todo: Add the animation here
        return OnExplode();
    }

    public abstract bool IsWalkable(bool isGhost);

    #endregion

    #region Protected Methods

    /// <summary>
    /// Reacts to explosions. Animations are already handled.
    /// </summary>
    protected abstract EnvironmentTileAbs OnExplode();

    #endregion

    #region Protected Fields

    [SerializeField]
    protected List<Sprite> m_explosionAnimation;

    [SerializeField]
    protected float m_explosionAnimationDuration;

    #endregion
}