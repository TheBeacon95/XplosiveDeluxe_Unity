using System.Collections;
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

    public void Explode() {
        // Todo: Add the animation here
        OnExplode();
    }

    public abstract bool IsWalkable(bool isGhost);

    #endregion

    #region Protected Methods

    /// <summary>
    /// Reacts to explosions. Animations are already handled.
    /// </summary>
    /// <param name="levelManager"></param>
    protected abstract void OnExplode();

    #endregion

    #region Protected Fields

    [SerializeField]
    protected List<Sprite> m_explosionAnimation;

    [SerializeField]
    protected float m_explosionAnimationDuration;

    protected LevelManagerIfc m_levelManager;

    #endregion

    #region Private Methods

    private void Awake() {
        // Todo: initialize LevelManager
        m_levelManager = null;
    }

    #endregion
}