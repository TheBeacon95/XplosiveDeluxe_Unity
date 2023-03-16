using UnityEngine;

public interface EntityIfc {

    /// <summary>
    /// Todo
    /// </summary>
    Vector2 Position {
        get;
    }

    Vector2Int Direction {
        get;
    }

    /// <summary>
    /// Returns wether the entity should use the idle sprites or the moving ones.
    /// </summary>
    bool IsIdle {
        get;
    }

}