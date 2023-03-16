using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Actor Sprite Handler", menuName = "Sprite Handlers/Actor")]
public class ActorSpriteHandler : SpriteHandlerAbs {

    #region SpriteHandlerAbs Members

    public override Sprite GetSprite(ref int index, EntityAbs entity) {
        return RetrieveSprite(entity.Direction, entity.IsIdle, ref index);
    }

    #endregion

    #region Private Methods

    private Sprite RetrieveSprite(Vector2Int direction, bool isIdle, ref int index) {
        List<Sprite> spriteListToUse;
        if (direction == Vector2Int.up) {
            spriteListToUse = isIdle ? m_upIdleSprites : m_upWalkSprites;
        }
        else if (direction == Vector2Int.right) {
            spriteListToUse = isIdle ? m_rightIdleSprites : m_rightWalkSprites;
        }
        else if (direction == Vector2Int.down) {
            spriteListToUse = isIdle ? m_downIdleSprites : m_downWalkSprites;
        }
        else if (direction == Vector2Int.left) {
            spriteListToUse = isIdle ? m_leftIdleSprites : m_leftWalkSprites;
        }
        else {
            spriteListToUse = m_downIdleSprites;
        }

        if (spriteListToUse == null || spriteListToUse.Count == 0) {
            return m_defaultSprite;
        }

        if (index >= spriteListToUse.Count) {
            index = 0;
        }
        return spriteListToUse[index++];
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private Sprite m_defaultSprite;

    [Header("Idle animations")]
    [SerializeField]
    private List<Sprite> m_upIdleSprites;

    [SerializeField]
    private List<Sprite> m_rightIdleSprites;

    [SerializeField]
    private List<Sprite> m_downIdleSprites;

    [SerializeField]
    private List<Sprite> m_leftIdleSprites;

    [Header("Walk animations")]
    [SerializeField]
    private List<Sprite> m_upWalkSprites;

    [SerializeField]
    private List<Sprite> m_rightWalkSprites;

    [SerializeField]
    private List<Sprite> m_downWalkSprites;

    [SerializeField]
    private List<Sprite> m_leftWalkSprites;

    #endregion

}