using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour {

    #region Public Methods

    public void StartExplosion(BombIfc bomb) {
        // todo: find out what happens when bricks are hit with brick maker explosions in original
        Vector2Int originPosition = bomb.Position;
        List<Vector2Int> explosionDirections = new List<Vector2Int>();

        Vector2Int[] allDirections = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
        foreach (Vector2Int direction in allDirections) {
            //if (m_levelManager.Explode(originPosition + direction)) {
            //    explosionDirections.Add(direction);
            //}
        }
        CreateOrigin(explosionDirections, bomb);
        foreach (Vector2Int direction in explosionDirections) {
            CreateDirectional(direction, bomb);
        }
    }

    #endregion

    #region Private Methods

    private void Awake() {
        m_explosionPositions = new List<Vector2Int>();
    }

    private void CreateOrigin(IList<Vector2Int> explosionDirections, BombIfc bomb) {
        if (m_explosionPositions.Contains(bomb.Position)) {
            // Update Explosion sprite
            // Refresh Explosion timer
        }
        else {
            ExplosionIfc origin = Instantiate(m_explosionPrefab, new Vector3(bomb.Position.x, bomb.Position.y), Quaternion.identity);
            m_explosionPositions.Add(origin.Position);
        }
    }

    private void CreateDirectional(Vector2Int direction, BombIfc bomb) {
        throw new NotImplementedException();
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private Explosion m_explosionPrefab;
    private LevelManagerIfc m_levelManager;
    private List<Vector2Int> m_explosionPositions;

    #endregion
}