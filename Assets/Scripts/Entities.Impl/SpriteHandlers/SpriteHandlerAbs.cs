using System.Collections.Generic;
using UnityEngine;

public abstract class SpriteHandlerAbs : ScriptableObject {

    #region Public Methods

    /// <summary>
    /// Returns the next sprite in the list of sprites to render.
    /// </summary>
    /// <param name="index">The index of the next sprite in the animation</param>
    /// <param name="entity">The entity that's being animated</param>
    public abstract Sprite GetSprite(ref int index, EntityAbs entity);

    #endregion

}