using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface LevelManagerIfc {

    #region Methods

    ///// <summary>
    /////
    ///// </summary>
    //void ToggleBlockState();

    ///// <summary>
    /////
    ///// </summary>
    //void SetBlockState(bool setOn);

    /// <summary>
    ///
    /// </summary>
    /// <param name="position"></param>
    void PlaceBlock(Vector2 position, Tile tile);

    ///// <summary>
    /////
    ///// </summary>
    ///// <param name="position"></param>
    //void TryPlaceItem(Vector2 position);

    /// <summary>
    /// Tries to place a bomb.
    /// </summary>
    /// <param name="properties">Properties of the bomb</param>
    /// <param name="position">Position where the bomb should be placed</param>
    /// <returns>
    /// null: Bomb could not be placed.
    /// UnityEvent: Destroyed event of the successfully created bomb
    /// </returns>
    //UnityEvent<Vector2Int> TryPlaceBomb(BombProperties properties, Vector2Int position);

    /// <summary>
    /// todo
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    bool IsBombPlaceable(Vector2Int position); // todo: Consider how bombs are placed.

    /// <summary>
    /// todo
    /// <param name="position"></param>
    void PlaceObject(GameObject item, Vector2 position); // Todo make an interface or something for items.

    /// <summary>
    /// Gets the actual direction the player will move in, based on the direction they are trying to move in.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="direction"></param>
    /// <param name="isGhost"></param>
    /// <returns></returns>
    Vector2Int GetWalkableDirection(Vector2 position, Vector2 desiredDirection, bool isGhost = false);

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
    IList<Vector2Int> GetAvailableDirections(Vector2Int position, bool isBrickMuncher = false);

    /// <summary>
    /// Returns the player closest to <paramref name="position"/>.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    Vector2 GetNearestPlayer(Vector2 position);

    /// <summary>
    /// Returns wether an object is betweenCells or exactly on one.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    bool IsBetweenBlocks(Vector2 position);

    /// <summary>
    /// Gets a manager of type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Component GetManager<T>();

    #endregion

    #region Properties

    /// <summary>
    /// Shows the On/Off block state.
    /// </summary>
    bool IsBlockStateOn {
        get;
    }

    #endregion
}