using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : EntityAbs, PlayerIfc {

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

    public void DecreaseLife() {
        Lives--;
        if (Lives < 0) {
            Lives = 0;
        }
    }

    public void IncreaseBombCount() {
        m_status.IncreaseBombCount();
    }

    public void IncreaseBombStrength() {
        m_status.IncreaseBombStrength();
    }

    public void IncreaseLifeCount() {
        m_status.IncreaseLifeCount();
    }

    public void IncreaseSpeed() {
        m_status.IncreaseSpeed();
    }

    public void SetBombCraze(float time) {
        m_status.SetBombCraze();
    }

    public void SetBrickMaker() {
        m_status.SetBrickMaker();
    }

    public void SetFirePower(float time) {
        m_status.SetFirePower();
    }

    public void SetGhost(float time) {
        m_status.SetGhost();
    }

    public void SetNausea(float time) {
        m_status.SetNausea();
    }

    public void SetShield(float time) {
        m_status.SetShield();
    }

    public void SetSlow() {
        m_status.SetSlow();
    }

    public void SetStuck(float time) {
        throw new System.NotImplementedException();
    }

    public void SetWeak() {
        m_status.MinimiseBombStrength();
    }

    public void Teleport(Vector2 newPosition) {
        throw new System.NotImplementedException();
    }

    #endregion

    #region EntityAbs Members

    public override Vector2 Position {
        get {
            return transform.position;
        }
    }

    public override Vector2Int Direction {
        get {
            return m_direction;
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private PlayerStatus m_status;

    [SerializeField]
    private PlayerControls m_controls;

    private int m_activeBombs;
    private Vector2Int m_direction;

    private LevelManagerIfc m_levelManager;

    // Constants
    private const float DEFAULT_EFFECT_TIME = 10f;
    private readonly YieldInstruction EFFECT_YIELD_INSTRUCTION = new WaitForSeconds(DEFAULT_EFFECT_TIME);

    #endregion

    #region Private Methods

    private void ResetAndStartEffectTimer() {
        throw new NotImplementedException();
    }

    private void ResetAllEffects() {
        throw new NotImplementedException();
    }

    private void Awake() {
        m_levelManager = transform.parent.GetComponent<LevelManagerIfc>();
    }

    private void Update() {
        // Move the player.
        if (m_isMoving) {
            // Do nothing
        }
        else {
            Vector2Int direction = m_controls.PressedDirection;
            if (direction != Vector2Int.zero) {
                TryMove(direction);
            }
        }
        if (m_controls.IsFirePressed && IsBombAvailable()) {
            PlaceBomb();
        }
        // TODO: Implement placing Bomb
    }

    private void PlaceBomb() {
        // todo: implement way better!
        BombProperties properties = new BombProperties();
        properties.Range = m_status.BombStrength;
        properties.IsBrickMaker = m_status.HasBrickMakerEffect;
        Vector2 pos = transform.position;

        UnityEvent<Vector2Int> destroyedEvent = m_levelManager.TryPlaceBomb(properties, pos.Round());
        if (destroyedEvent != null) {
            m_activeBombs++;
            destroyedEvent.AddListener((Vector2Int) => {
                m_activeBombs--;
            });
        }
    }

    private bool IsBombAvailable() {
        return (m_status.BombCount - m_activeBombs) > 0;
    }

    private void TryMove(Vector2 direction) {
        Vector2 movableDirection = m_levelManager.GetWalkableDirection(transform.position, direction, m_status.HasGhostEffect);
        if (movableDirection == Vector2.zero) {
            SetDirection(direction);
        }
        else {
            SetDirection(movableDirection);
            StartCoroutine(Move(movableDirection, (int)m_status.Speed));
        }
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
