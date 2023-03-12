using UnityEngine.Events;

/// <summary>
/// Provides an interface for all parts of an explosion.
/// </summary>
public interface ExplosionIfc : EntityIfc {

    #region Properties

    bool IsBrickMaker {
        get;
    }

    int DirectionCount {
        get;
    }

    #endregion

    #region Events

    UnityEvent<ExplosionIfc> SubsidedEvent {
        get;
    }

    #endregion

}