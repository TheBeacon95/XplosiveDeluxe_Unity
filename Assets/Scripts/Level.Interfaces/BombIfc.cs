using UnityEngine;
using UnityEngine.Events;

public interface BombIfc {

    #region Properties

    bool IsBrickMaker {
        get;
    }

    int Strength {
        get;
    }

    Vector2Int Position {
        get;
    }

    #endregion

    #region Methods

    void Destroy();

    #endregion

    #region Events

    UnityEvent<Vector2Int> DestroyedEvent {
        get;
    }

    #endregion
}