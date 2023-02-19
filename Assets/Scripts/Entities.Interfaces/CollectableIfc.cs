/// <summary>
/// Provides an abstraction for items of all kinds.
/// </summary>
public interface CollectableIfc {

    #region Methods

    /// <summary>
    /// Gets called, when a player collects it.
    /// </summary>
    /// <param name="player"></param>
    void Collect(PlayerIfc player);

    /// <summary>
    /// Gets called when it's destroyed.
    /// </summary>
    void Destroy();

    #endregion
}