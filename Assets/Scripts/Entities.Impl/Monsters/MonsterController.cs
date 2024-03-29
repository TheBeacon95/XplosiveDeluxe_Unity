using UnityEngine;

public class MonsterController : EntityAbs {

    #region Private Methods

    private void Awake() {
        m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_levelManager = transform.parent.GetComponent<LevelManagerIfc>();
        if (m_levelManager == null || m_type == null || !m_type.IsConfiguredProperly()) {
            // The Monster or the level wasn't configured properly.
            Destroy(gameObject);
        }
    }

    private void Start() {
        m_type.Init(this, m_levelManager);
    }

    private void Update() {
        // Move the player.
        if (m_isMoving || m_isStalled) {
            return;
        }

        Vector2Int direction = m_type.GetDirection(this, m_levelManager);
        DoMove(direction);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerLayer")) {
            Attack(other.gameObject.GetComponent<PlayerIfc>());
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("ItemLayer")) {
            Collect(other.gameObject.GetComponent<CollectableIfc>());
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("ExplosionLayer")) {
            Explode(other.gameObject.GetComponent<ExplosionIfc>());
        }
    }

    private void Attack(PlayerIfc player) {
        if (!m_isStalled && player != null) {
            m_type.Attack(player);
        }
    }

    private void Collect(CollectableIfc collectable) {
        m_type.Collect(collectable);
    }

    private void Explode(ExplosionIfc explosion) {
        m_type.Explode(this, explosion);
    }

    //private void Move() {
    //    m_type.Move(this, m_levelManager);
    //}

    #endregion

    #region Public Methods

    public void DoMove(Vector2Int direction) {
        m_direction = direction;
        if (m_direction == Vector2Int.zero) {
            IsIdle = true;
        }
        else {
            IsIdle = false;
            StartCoroutine(Move(m_direction, m_type.Speed));
        }
    }

    #endregion

    #region Public Properties

    public MonsterType Type {
        get {
            return m_type;
        }
        set {
            if(m_type != value) {
                m_type.Stop(this, false);
                m_type = value;
                m_type.LateInit(this, m_levelManager);
            }
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private MonsterType m_type;

    private SpriteRenderer m_spriteRenderer;
    private LevelManagerIfc m_levelManager;

    private Vector2Int m_direction;
    private bool m_isStalled;

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
            return m_type.SpriteHandler;
        }
    }

    public override bool IsStalled {
        get {
            return m_isStalled;
        }
        set {
            m_isStalled = value;
        }
    }

    #endregion
}