using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Represents all blocks that change when the on/off state changes.
/// Todo: Consider making subclasses.
/// </summary>
[CreateAssetMenu(fileName = "StateBlockTile", menuName = "Tiles/StateBlockTile")]
public class StateBlockTile : EnvironmentTileAbs {

    #region EnvironmentTileAbs Members

    public override bool IsWalkable(bool isGhost) {
        switch (m_type) {
            case StateBlockType.OnBlock:
                return !m_levelManager.IsBlockStateOn;
            case StateBlockType.OffBlock:
                return m_levelManager.IsBlockStateOn;
            case StateBlockType.OnSwitch:
            case StateBlockType.OffSwitch:
            case StateBlockType.StateSwitch:
                return false;
            case StateBlockType.None:
            default:
                // Todo: assert!
                return true;
        }
    }

    protected override void OnExplode() {
        switch (m_type) {
            case StateBlockType.OnSwitch:
                break;
            case StateBlockType.OffSwitch:
                break;
            case StateBlockType.StateSwitch:
                break;
            case StateBlockType.OnBlock:
            case StateBlockType.OffBlock:
            case StateBlockType.None:
            default:
                // Do nothing.
                break;
        }
    }

    #endregion

    #region BlockStateIfc

    public void OnBlockStateChanged() {
        // Todo: Add animation here
        UpdateSprite();
    }

    #endregion

    #region Private Methods

    private void UpdateSprite() {
        sprite = m_levelManager.IsBlockStateOn ? m_onSprite : m_offSprite;
    }

    #endregion

    #region Private Fields

    private StateBlockType m_type;
    private Sprite m_onSprite;
    private Sprite m_offSprite;
    private List<Sprite> m_onSpriteList;
    private List<Sprite> m_offSpriteList;

    #endregion
}
