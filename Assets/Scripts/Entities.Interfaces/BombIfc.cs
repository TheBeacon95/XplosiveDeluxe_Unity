using UnityEngine;
using UnityEngine.Events;

public interface BombIfc : EntityIfc {

    #region Properties

    bool IsBrickMaker {
        get;
    }

    int Strength {
        get;
    }

    BombProperties Properties {
        get;
        set;
    }

    #endregion

    #region Methods

    void Destroy();

    #endregion

    #region Events

    UnityEvent<Vector2Int> DestroyedEvent {
        get;
    }

    UnityEvent<BombIfc> ExplodedEvent {
        get;
    }

    #endregion
}