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
    private void Update() {
        // Move the player.
        if (IsMoving) {
            // Do nothing
        }
        else {
            m_direction = m_type.GetDirection(this, m_levelManager);
            StartCoroutine(Move(m_direction, m_type.Speed));
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerLayer")) {
            m_type.Attack(this, other.gameObject.GetComponent<PlayerIfc>());
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("ItemLayer")) {
            m_type.Collect(this, other.gameObject.GetComponent<CollectableIfc>());
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("ExplosionLayer")) {
            m_type.Explode(this, other.gameObject.GetComponent<ExplosionIfc>());
        }
    }

    //private void Move() {
    //    m_type.Move(this, m_levelManager);
    //}

    #endregion

    #region Private Fields

    [SerializeField]
    private MonsterType m_type;

    private SpriteRenderer m_spriteRenderer;
    private LevelManagerIfc m_levelManager;

    private Vector2Int m_direction;

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

    #endregion
}