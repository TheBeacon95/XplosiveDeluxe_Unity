using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Sprite Handler", menuName = "Sprite Handlers/Default")]
public class DefaultSpriteHandler : SpriteHandlerAbs {

    #region SpriteHandlerAbs Members

    public override Sprite GetSprite(ref int index, EntityAbs entity) {
        if (m_sprites == null) {
            return m_defaultSprite;
        }
        else {
            Sprite spriteToSet = m_sprites[index++];
            index %= m_sprites.Count;
            return spriteToSet;
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private List<Sprite> m_sprites;

    [SerializeField]
    private Sprite m_defaultSprite;

    #endregion

}