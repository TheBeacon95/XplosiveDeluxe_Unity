using UnityEngine;
/// <summary>
/// Todo
/// </summary>
[CreateAssetMenu(fileName = "DestructibleBlockTile", menuName = "Tiles/DestructibleBlockTile")]
public sealed class DestructibleBlockTile : EnvironmentTileAbs {

    #region EnvironmentTileAbs

    public override bool IsWalkable(bool isGhost) {
        return isGhost;
    }

    protected override void OnExplode() {
        m_health--;
        if (m_health <= 0 || m_isPassthroughDestructible) {
            // Destroy the block
            m_levelManager.DestroyTile(transform.GetPosition());
        }
        else {
            // Change the sprite
        }
    }

    public override bool IsExplosionStopper {
        get {
            return !m_isPassthroughDestructible;
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private int m_health;

    [SerializeField]
    private bool m_isPassthroughDestructible;

    #endregion
}