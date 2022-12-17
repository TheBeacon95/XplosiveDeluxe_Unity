using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour {

    private SpriteRenderer m_spriteRenderer;
    private int m_animationFrame = 0;

    public Sprite[] animationSprites;
    public Sprite idleSprite;
    public float AnimationTime = 0.25f;
    public bool doLoop = true;
    public bool isIdle = true;

    private void Awake() {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        m_spriteRenderer.enabled = true;
    }

    private void OnDisable() {
        m_spriteRenderer.enabled = false;
    }

    private void NextFrame() {
        if (isIdle) {
            m_spriteRenderer.sprite = idleSprite;
            m_animationFrame = 0;
        }
        else {
            m_animationFrame++;
            if (doLoop && m_animationFrame >= animationSprites.Length) {
                m_animationFrame = 0;
            }
            if (m_animationFrame < animationSprites.Length) {
                m_spriteRenderer.sprite = animationSprites[m_animationFrame];
            }
        }
    }

    private void Start() {
        InvokeRepeating(nameof(NextFrame), AnimationTime, AnimationTime);
    }
}
