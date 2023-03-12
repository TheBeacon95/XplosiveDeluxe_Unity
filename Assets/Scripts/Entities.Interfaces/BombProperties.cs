/// <summary>
/// Represents the properties of a bomb.
/// </summary>
public class BombProperties {
    /// <summary>
    /// The size of the explosion.
    /// </summary>
    public int Range {
        get;
        set;
    }

    /// <summary>
    /// If true, the explosion will spawn bricks when it's done.
    /// </summary>
    public bool IsBrickMaker {
        get;
        set;
    }
}
