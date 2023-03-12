using UnityEngine;
/// <summary>
/// Todo
/// </summary>
[CreateAssetMenu(fileName = "DestructibleBlockTile", menuName = "Tiles/DestructibleBlockTile")]
public class DestructibleBlockTile : EnvironmentTileAbs {

    #region EnvironmentTileAbs

    public override bool IsWalkable(bool isGhost) {
        return isGhost;
    }

    protected override EnvironmentTileAbs OnExplode() {
        return null;
    }

    public override bool IsExplosionStopper {
        get {
            return !m_isPassthroughDestructible;
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private bool m_isPassthroughDestructible;

    #endregion
}