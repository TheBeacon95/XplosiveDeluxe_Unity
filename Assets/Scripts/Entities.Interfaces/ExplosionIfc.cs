using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Provides an interface for all parts of an explosion.
/// </summary>
public interface ExplosionIfc {

    #region Properties

    bool IsBrickMaker {
        get;
    }

    int DirectionCount {
        get;
    }

    Vector2Int Position {
        get;
    }

    #endregion

    #region Events

    UnityEvent SubsidedEvent {
        get;
    }

    #endregion

}