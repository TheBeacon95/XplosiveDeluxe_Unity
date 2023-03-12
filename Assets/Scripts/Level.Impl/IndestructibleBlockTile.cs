using UnityEngine;
/// <summary>
/// This class represents all wall like block tiles.
/// </summary>
[CreateAssetMenu(fileName = "IndestructibleBlockTile", menuName = "Tiles/IndestructibleBlockTile")]
public sealed class IndestructibleBlockTile : EnvironmentTileAbs {

    #region EnvironmentTileAbs Members

    public override bool IsWalkable(bool isGhost) {
        return false;
    }

    protected override EnvironmentTileAbs OnExplode() {
        return this;
    }


    #endregion
}