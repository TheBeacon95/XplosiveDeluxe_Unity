using UnityEngine;
using UnityEngine.Events;

public interface BombIfc {

    #region Methods

    void Destroy();

    #endregion

    #region Events

    UnityEvent<Vector2Int> DestroyedEvent {
        get;
    }

    #endregion
}