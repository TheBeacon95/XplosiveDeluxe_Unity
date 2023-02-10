using UnityEngine;
/// <summary>
/// Todo
/// </summary>
public interface PlayerIfc {

    #region Properties

    /// <summary>
    /// The name that should be displayed instead of Player X
    /// </summary>
    string Name {
        get;
    }

    /// <summary>
    /// The number of remaining lives the player has.
    /// </summary>
    int Lives {
        get;
    }

    /// <summary>
    /// True if the player currently has the ghost effect.
    /// </summary>
    bool IsGhost {
        get;
    }

    /// <summary>
    /// Exposes the exact position of the player.
    /// </summary>
    Vector2 Position {
        get;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Teleports the player to <paramref name="newPosition"/>.
    /// </summary>
    /// <param name="newPosition"></param>
    void Teleport(Vector2 newPosition);

    /// <summary>
    /// Increases the length of the players bomb explosion by one.
    /// </summary>
    void IncreaseBombLength();

    /// <summary>
    /// Increases the amount of available bombs by one.
    /// </summary>
    void IncreaseBombCount();

    /// <summary>
    /// Increases the speed of the player by one.
    /// </summary>
    void IncreaseSpeed();

    /// <summary>
    /// Increases the number of remaining lives by one.
    /// </summary>
    void IncreaseLifeCount();

    /// <summary>
    /// Renders the player unable to move for <paramref name="time"/> seconds.
    /// </summary>
    /// <param name="time">
    /// Time in seconds (Default time is used if not specified.)
    /// </param>
    void SetStuck(float time = 0); // Todo: resolve this potential issue: If the player gets stuck while lerping, make sure the position still matches the grid (multiple of 1/8).

    /// <summary>
    /// Sets the ghost effect for <paramref name="time"/> seconds.
    /// </summary>
    /// <param name="time">
    /// Time in seconds (Default time is used if not specified.)
    /// </param>
    void SetGhost(float time = 0);

    /// <summary>
    /// Sets the nausea effect for <paramref name="time"/> seconds.
    /// </summary>
    /// <param name="time">
    /// Time in seconds (Default time is used if not specified.)
    /// </param>
    void SetNausea(float time = 0);

    /// <summary>
    /// Sets the shield effect for <paramref name="time"/> seconds.
    /// </summary>
    /// <param name="time">
    /// Time in seconds (Default time is used if not specified.)
    /// </param>
    void SetShield(float time = 0);

    /// <summary>
    /// Reduces the players speed to the minimum.
    /// </summary>
    void SetSlow();

    /// <summary>
    /// Lets the next bomb spawn bricks.
    /// </summary>
    void SetBrickMaker();

    /// <summary>
    /// Forces the player to continually place all available bombs for <paramref name="time"/> seconds.
    /// </summary>
    /// <param name="time">
    /// Time in seconds (Default time is used if not specified.)
    /// </param>
    void SetBombCraze(float time = 0);

    /// <summary>
    /// Allows the player to shoot fire for <paramref name="time"/> seconds.
    /// </summary>
    /// <param name="time">
    /// Time in seconds (Default time is used if not specified.)
    /// </param>
    void SetFirePower(float time = 0);

    /// <summary>
    /// Reduces the length of the players bomb explosion to the minimum.
    /// </summary>
    void SetWeak();

    /// <summary>
    /// Decreases the life count of the player by one.
    /// </summary>
    void DecreaseLife();

    #endregion
}