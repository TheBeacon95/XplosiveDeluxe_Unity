using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LevelManagerIfc {

    #region Methods

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="objectToInstantiate"></param>
    /// <param name="position"></param>
    //void InstantiateGameObject(GameObject objectToInstantiate, Vector2 position);

    /// <summary>
    ///
    /// </summary>
    /// <param name="position"></param>
    /// <param name="time_s"></param>
    void DestroyTile(Vector2 position, float time_s = 0);

    /// <summary>
    ///
    /// </summary>
    void ToggleBlockState();

    /// <summary>
    ///
    /// </summary>
    void SetBlockState(bool setOn);

    /// <summary>
    ///
    /// </summary>
    /// <param name="position"></param>
    void PlaceBlock(Vector2 position);

    /// <summary>
    ///
    /// </summary>
    /// <param name="position"></param>
    void TryPlaceItem(Vector2 position);

    /// <summary>
    ///
    /// <param name="position"></param>
    void PlaceItem(GameObject item, Vector2 position); // Todo make an interface or something for items.

    /// <summary>
    /// Gets the actual direction the player will move in, based on the direction they are trying to move in.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    Vector2 GetMovableDirection(Vector2 position, Vector2 direction);

    /// <summary>
    /// Explodes the block at <paramref name="position"/>.
    /// </summary>
    /// <param name="position"></param>
    /// <returns>
    /// Returns whether the explosion was stopped.
    /// True: The explosion was stopped - False: It wasn't.
    /// </returns>
    bool TryExplode(Vector2 position);

    /// <summary>
    /// Returns all the directions a monster can go in.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="isBrickMuncher"></param>
    /// <returns></returns>
    IList<Vector2> GetAvailableDirections(Vector2 position, bool isBrickMuncher = false);

    /// <summary>
    /// Returns the player closest to <paramref name="position"/>.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    Vector2 GetNearestPlayer(Vector2 position);

    #endregion

    #region Properties

    /// <summary>
    /// Shows the On/Off block state.
    /// </summary>
    BlockState BlockState {
        get;
    }

    #endregion
}