using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class PlayerController : EntityAbs, PlayerIfc {

    #region PlayerIfc Members

    public UnityEvent<Vector2Int> DirectionChangedEvent {
        get;
        private set;
    }

    public UnityEvent<bool> IsMovingChangedEvent {
        get;
        private set;
    }

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

    public void Kill() {
        if (!m_status.HasShieldEffect) {
            Die();
        }
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

    public override SpriteHandlerAbs SpriteHandler {
        get {
            return m_spriteHandler;
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private PlayerStatus m_status;

    [SerializeField]
    private PlayerControls m_controls;

    [SerializeField]
    private SpriteHandlerAbs m_spriteHandler;

    [SerializeField]
    private Tile m_deathBlock;

    private int m_activeBombs;
    private Vector2Int m_direction;

    private LevelManagerIfc m_levelManager;
    private BombManagerIfc m_bombManager;
    private bool m_isIdle;

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

    private void Die() {
        m_levelManager.PlaceBlock(Position, m_deathBlock);
        Destroy(gameObject);
    }

    private void Awake() {
        m_isIdle = true;
        m_levelManager = transform.parent.GetComponent<LevelManagerIfc>();
        m_bombManager = (BombManagerIfc)m_levelManager.GetManager<BombManagerIfc>();
        DirectionChangedEvent = new UnityEvent<Vector2Int>();
        IsMovingChangedEvent = new UnityEvent<bool>();
    }

    private void Update() {
        // Move the player.
        if (IsMoving) {
            // Do nothing
        }
        else {
            Vector2Int direction = m_controls.PressedDirection;
            if (direction == Vector2Int.zero) {
                SetIsIdle(true);
            }
            else {
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

        UnityEvent<Vector2Int> destroyedEvent = m_bombManager.CreateBomb(properties, pos.Round());
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

    private void TryMove(Vector2Int direction) {
        Vector2Int movableDirection = m_levelManager.GetWalkableDirection(transform.position, direction, m_status.HasGhostEffect);
        if (movableDirection == Vector2.zero) {
            SetDirection(direction);
            SetIsIdle(true);
        }
        else {
            SetIsIdle(false);
            SetDirection(movableDirection);
            StartCoroutine(Move(movableDirection, m_status.Speed));
        }
    }

    private void SetDirection(Vector2Int newDirection) {
        if (m_direction != newDirection) {
            m_direction = newDirection;
            DirectionChangedEvent.Invoke(newDirection);
        }
    }

    private void SetIsIdle(bool isIdle) {
        if (m_isIdle != isIdle) {
            m_isIdle = isIdle;
            IsMovingChangedEvent.Invoke(!isIdle);
        }
    }

    #endregion
}
