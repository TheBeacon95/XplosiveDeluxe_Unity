using System.Collections;
using UnityEngine;

public class Animator : MonoBehaviour {

    #region Private Methods

    private void Awake() {
        m_spriteIndex = 0;
        m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start() {
        m_spriteHandler.Setup(gameObject.GetComponentInParent<PlayerIfc>());
        StartCoroutine(Animate());
    }

    private IEnumerator Animate() {
        while (true) {
            m_spriteRenderer.sprite = m_spriteHandler.GetSprite(ref m_spriteIndex);
            yield return ANIMATION_YIELD_INSTRUCTION;
        }
    }

    #endregion

    #region Private Fields

    private int m_spriteIndex;
    private SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private MovementSpriteHandlerAbs m_spriteHandler;

    private const float ANIMATION_FRAME_RATE = 1f / 12f;
    private static readonly YieldInstruction ANIMATION_YIELD_INSTRUCTION = new WaitForSeconds(ANIMATION_FRAME_RATE);

    #endregion

}
