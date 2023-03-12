using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : EntityAbs, BombIfc {
    public UnityEvent<Vector2Int> DestroyedEvent {
        get;
        private set;
    }

    public UnityEvent<BombIfc> ExplodedEvent {
        get;
        private set;
    }

    public bool IsBrickMaker {
        get {
            return false;
        }
    }

    public int Strength {
        get {
            return m_strength;
        }
        set {
            m_strength = value;
        }

    }

    public new Vector2Int Position {
        get {
            return transform.position.ToVector2().Round();
        }
    }

    public BombProperties Properties {
        get;
        set;
    }

    public void Destroy() {
        DestroyedEvent.Invoke(Position);
        Destroy(gameObject);
    }

    private void Explode() {
        ExplodedEvent.Invoke(this);
        Destroy();
    }

    #region Private Methods

    private void Awake() {
        DestroyedEvent = new UnityEvent<Vector2Int>();
        ExplodedEvent = new UnityEvent<BombIfc>();
    }

    private void Start() {
        StartCoroutine(ExplosionCoroutine());
    }

    private IEnumerator ExplosionCoroutine() {
        yield return EXPLOSION_YIELD_INSTRUCTION;
        Explode();
    }

    #endregion

    #region EntityAbs Members

    public override SpriteHandlerAbs SpriteHandler {
        get {
            return m_spriteHandler;
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private int m_strength;

    [SerializeField]
    private SpriteHandlerAbs m_spriteHandler;

    private const float EXPLOSION_TIME = 4f;
    private static readonly WaitForSeconds EXPLOSION_YIELD_INSTRUCTION = new WaitForSeconds(EXPLOSION_TIME);

    #endregion
}
