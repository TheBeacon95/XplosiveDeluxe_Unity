using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour, BombIfc {
    public UnityEvent<Vector2Int> DestroyedEvent {
        get;
        private set;
    }

    public void Destroy() {
        DestroyedEvent.Invoke(transform.position.ToVector2().Round());
        Destroy(gameObject);
    }

    #region Private Methods

    private void Awake() {
        DestroyedEvent = new UnityEvent<Vector2Int>();
    }

    private void Start() {
        StartCoroutine(ExplosionCoroutine());
    }

    private IEnumerator ExplosionCoroutine() {
        yield return EXPLOSION_YIELD_INSTRUCTION;
        Destroy();
        // Todo: Implement Explode() and use it here.
    }

    #endregion

    #region Private Fields

    private const float EXPLOSION_TIME = 4f;
    private static readonly WaitForSeconds EXPLOSION_YIELD_INSTRUCTION = new WaitForSeconds(EXPLOSION_TIME);

    #endregion
}
