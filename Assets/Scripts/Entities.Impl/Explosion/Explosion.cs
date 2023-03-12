using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : EntityAbs, ExplosionIfc {

    #region Public Properties

    public List<Vector2Int> Directions {
        get;
        set;
    }

    #endregion

    #region EntityAbs Members

    public override SpriteHandlerAbs SpriteHandler {
        get {
            return m_spriteHandler;
        }
    }

    #endregion

    #region Private Methods

    private void Awake() {
        Directions = new List<Vector2Int>();
        m_collider = GetComponent<Collider2D>();
        SubsidedEvent = new UnityEvent<ExplosionIfc>();
    }

    private void Start() {
        StartCoroutine(Persist());
    }

    private IEnumerator Persist() {
        yield return new WaitForSeconds(1f); // TODO: finish this code.
        SubsidedEvent.Invoke(this);
        Destroy(gameObject);
    }

    #endregion

    #region Private Fields

    private Collider2D m_collider;
    [SerializeField]
    private DefaultSpriteHandler m_spriteHandler;

    #endregion

    #region ExplosionIfc Members

    public bool IsBrickMaker => throw new System.NotImplementedException();

    public int DirectionCount => throw new System.NotImplementedException();

    public UnityEvent<ExplosionIfc> SubsidedEvent {
        get;
        private set;
    }

    #endregion
}
