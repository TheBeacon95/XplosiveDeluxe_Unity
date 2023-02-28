using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementSpriteHandler", menuName = "Player/SpriteHandler")]
public class PlayerMovementSpriteHandler : MovementSpriteHandlerAbs {

    #region Private Fields

    [Header("Idle animations")]
    [SerializeField]
    private List<Sprite> m_upIdle;
    [SerializeField]
    private List<Sprite> m_rightIdle;
    [SerializeField]
    private List<Sprite> m_downIdle;
    [SerializeField]
    private List<Sprite> m_leftIdle;

    [Header("Walking animations")]
    [SerializeField]
    private List<Sprite> m_upWalk;
    [SerializeField]
    private List<Sprite> m_rightWalk;
    [SerializeField]
    private List<Sprite> m_downWalk;
    [SerializeField]
    private List<Sprite> m_leftWalk;

    // Logic
    private Vector2Int m_direction = Vector2Int.down;
    private bool m_isMoving = false;

    #endregion

    #region Private Methods

    //Todo move
    public override void Setup(PlayerIfc player) {
        player.DirectionChangedEvent.AddListener(OnDirectionChanged);
        player.IsMovingChangedEvent.AddListener(OnIsMovingChanged);
        UpdateSpriteList();
    }

    private void OnDirectionChanged(Vector2Int newDirection) {
        m_direction = newDirection;
        UpdateSpriteList();
    }

    private void OnIsMovingChanged(bool isMoving) {
        m_isMoving = isMoving;
        UpdateSpriteList();
    }

    private void UpdateSpriteList() {
        if (m_direction == Vector2Int.up) {
            m_activeSpriteList = m_isMoving ? m_upWalk : m_upIdle;
        }
        else if (m_direction == Vector2Int.right) {
            m_activeSpriteList = m_isMoving ? m_rightWalk : m_rightIdle;
        }
        else if (m_direction == Vector2Int.down) {
            m_activeSpriteList = m_isMoving ? m_downWalk : m_downIdle;
        }
        else if (m_direction == Vector2Int.left) {
            m_activeSpriteList = m_isMoving ? m_leftWalk : m_leftIdle;
        }
    }

    #endregion

}