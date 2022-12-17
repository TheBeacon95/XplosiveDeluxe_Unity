using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, PlayerIfc {

    #region PlayerIfc Members

    public string Name {
        get;
        private set;
    }

    public int Lives {
        get;
        private set;
    }

    public bool IsGhost {
        get;
        private set;
    }

    public Vector2 Position {
        get {
            return transform.position;
        }
    }

    public void DecreaseLife() {
        Lives--;
        if (Lives < 0) {
            Lives = 0;
        }
    }

    public void IncreaseBombCount() {
        if (m_bombCount < MAX_BOMB_COUNT) {
            m_bombCount++;
        }
    }

    public void IncreaseBombLength() {
        if (m_bombLength < MAX_BOMB_LENGTH) {
            m_lifeCount++;
        }
    }

    public void IncreaseLifeCount() {
        if (m_lifeCount < MAX_LIFE_COUNT) {
            m_lifeCount++;
        }
    }

    public void IncreaseSpeed() {
        if (m_speed < MAX_SPEED) {
            m_speed++;
        }
    }

    public void SetBombCraze(float time) {
        ResetAllEffects();
        m_isBombCrazy = true;
        ResetAndStartEffectTimer();
    }

    public void SetBrickMaker() {
        throw new System.NotImplementedException();
    }

    public void SetFirePower(float time) {
        throw new System.NotImplementedException();
    }

    public void SetGhost(float time) {
        throw new System.NotImplementedException();
    }

    public void SetNausea(float time) {
        throw new System.NotImplementedException();
    }

    public void SetShield(float time) {
        throw new System.NotImplementedException();
    }

    public void SetSlow() {
        throw new System.NotImplementedException();
    }

    public void SetStuck(float time) {
        throw new System.NotImplementedException();
    }

    public void SetWeak() {
        throw new System.NotImplementedException();
    }

    public void Teleport(Vector2 newPosition) {
        throw new System.NotImplementedException();
    }

    #endregion

    #region Private Fields


    [SerializeField]
    private int m_bombCount;
    [SerializeField]
    private int m_bombLength;
    [SerializeField]
    private int m_lifeCount;
    [SerializeField]
    private int m_speed;
    [SerializeField]
    private bool m_isBombCrazy;
    [SerializeField]
    private bool m_isGhost;

    private bool m_isMoving;
    private int m_activeBombs;

    [SerializeField]
    private LevelManagerIfc m_levelManager;

    private KeyCode m_inputUp = KeyCode.W;
    private KeyCode m_inputDown = KeyCode.S;
    private KeyCode m_inputLeft = KeyCode.A;
    private KeyCode m_inputRight = KeyCode.D;
    private KeyCode m_inputFire = KeyCode.Space;

    // Constants
    private const int MAX_BOMB_COUNT = 8; // Maximum number of bombs a player can have.
    private const int MAX_BOMB_LENGTH = 10; // Maximum length of a bomb explosion.
    private const int MAX_LIFE_COUNT = 10; // Maximum amount of lives a player can have.
    private const int MAX_SPEED = 10; // Maximum speed a player can have.

    private const float DEFAULT_EFFECT_TIME = 10f;
    private readonly YieldInstruction DEFAULT_YIELD_INSTRUCTION = new WaitForSeconds(DEFAULT_EFFECT_TIME);

    #endregion

    #region Private Methods

    private void ResetAndStartEffectTimer() {
        throw new NotImplementedException();
    }

    private void ResetAllEffects() {
        throw new NotImplementedException();
    }

    private void Start() {
        m_levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update() {
        // TODO: Evtl. for Dimi: Make it so that no key hay priority over others. Suggestion: save the currently pressed key and ignore other key presses until the key is released.
        if (m_isMoving) {
            // Do nothing
        }
        else if (Input.GetKey(m_inputUp)) {
            TryMove(Vector2.up);
        }
        else if (Input.GetKey(m_inputDown)) {
            TryMove(Vector2.down);
        }
        else if (Input.GetKey(m_inputLeft)) {
            TryMove(Vector2.left);
        }
        else if (Input.GetKey(m_inputRight)) {
            TryMove(Vector2.right);
        }
        else {
            SetDirection(Vector2.zero);
        }
        //if (Input.GetKey(m_inputFire) && IsBombAvailable()) {
        //    PlaceBomb();
        //}
        // TODO: Implement placing Bomb
    }

    //private bool IsBombAvailable() {
    //    return (m_bombCount - m_availableBombs) > 0;
    //}

    private void TryMove(Vector2 direction) {
        Vector2 movableDirection = m_levelManager.GetWalkableDirection(transform.position, direction, m_isGhost);
        if (movableDirection == Vector2.zero) {
            SetDirection(direction);
        }
        else {
            m_isMoving = true;
            SetDirection(movableDirection);
            StartCoroutine(Move(movableDirection));
        }
    }

    private IEnumerator Move(Vector2 direction) {
        float timeToMove = 1f / m_speed / 8;
        float elapsedTime = 0f;
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = originalPosition + direction / 8;

        while (elapsedTime < timeToMove) {
            transform.position = Vector2.Lerp(originalPosition, targetPosition, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        m_isMoving = false;
    }

    private void SetDirection(Vector2 newDirection) {
        //if (m_direction == newDirection) {
        //    return;
        //}

        //m_direction = newDirection;
        //DisableAllSpriteRenderers();

        //if (m_direction == Vector2.up) {
        //    m_activeSpriteRenderer = m_spriteRendererUp;
        //}
        //else if (m_direction == Vector2.down) {
        //    m_activeSpriteRenderer = m_spriteRendererDown;
        //}
        //else if (m_direction == Vector2.left) {
        //    m_activeSpriteRenderer = m_spriteRendererLeft;
        //}
        //else if (m_direction == Vector2.right) {
        //    m_activeSpriteRenderer = m_spriteRendererRight;
        //}
        //else {
        //    // Do nothing
        //}

        #endregion
    }
}
