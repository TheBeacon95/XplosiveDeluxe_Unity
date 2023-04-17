using System.Collections;
using UnityEngine;

public class Animator : MonoBehaviour {

    #region Private Fields

    private SpriteRenderer m_spriteRenderer;
    private int m_index;
    private readonly YieldInstruction m_animationYieldInstruction = new WaitForSeconds(1f / 12f); // Todo: improve

    private SpriteHandlerAbs m_spriteHandler;
    private EntityAbs m_entity;

    #endregion

    #region Private Methods

    private void Awake() {
        m_spriteRenderer = GetComponentInParent<SpriteRenderer>();
        m_entity = GetComponentInParent<EntityAbs>();
        m_spriteHandler = m_entity.SpriteHandler;
        m_index = 0;
    }

    private void Start() {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate() {
        while (true) {
            m_spriteRenderer.sprite = m_spriteHandler.GetSprite(ref m_index, m_entity);
            yield return m_animationYieldInstruction;
        }
    }

    #endregion

}