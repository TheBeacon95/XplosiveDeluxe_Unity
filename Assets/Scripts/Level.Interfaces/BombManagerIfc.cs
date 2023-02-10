using UnityEngine;

/// <summary>
/// Keeps track of all placed bombs and provides information about their positions.
/// </summary>
public interface BombManagerIfc {

    #region Methods

    /// <summary>
    /// Checks wether a bomb is at <paramref name="position"/>.
    /// </summary>
    /// <param name="position"></param>
    /// <returns>
    /// true: bomb is there, false: no bomb is there.
    /// </returns>
    bool IsBombHere(Vector2Int position);

    /// <summary>
    /// If bombs are available, this method will return the position of a random one.
    /// </summary>
    /// <returns>
    /// null: no bombs available
    /// Vector2Int: position of random bomb.
    /// </returns>
    Vector2Int? GetRandomBomb();

    #endregion

}