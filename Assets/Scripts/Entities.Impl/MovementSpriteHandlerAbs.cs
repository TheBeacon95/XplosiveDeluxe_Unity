using System.Collections.Generic;
using UnityEngine;

public abstract class MovementSpriteHandlerAbs : ScriptableObject {

    #region Public Methods

    public Sprite GetSprite(ref int index) {
        if (m_activeSpriteList.Count <= 0) {
            return m_defaultSprite;
        }
        if (m_activeSpriteList.Count <= index) {
            index = 0;
        }
        Sprite spriteToShow = m_activeSpriteList[index];
        index++;
        return spriteToShow;
    }

    #endregion

    public abstract void Setup(PlayerIfc player);

    #region Protected Fields

    [SerializeField]
    protected List<Sprite> m_activeSpriteList;

    [SerializeField]
    protected Sprite m_defaultSprite;

    #endregion

}
