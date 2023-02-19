using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombManager : MonoBehaviour, BombManagerIfc {

    #region Public Methods

    /// <summary>
    /// Checks if a bomb can be placed and then creates it.
    /// </summary>
    /// <param name="properties"></param>
    /// <param name="position"></param>
    /// <returns>
    /// The event that is fired, when the bomb is destroyed.
    /// </returns>
    public UnityEvent<Vector2Int> CreateBomb(BombProperties properties, Vector2Int position, LevelManager levelManager) {
        if (!levelManager.IsBombPlaceable(position)) {
            return null;
        }
        else {
            // Todo: add properties.
            Bomb bomb = Instantiate(m_bombPrefab, new Vector3(position.x, position.y), Quaternion.identity);
            m_activeBombs.Add(position);
            bomb.DestroyedEvent.AddListener(OnBombDestroyed);
            return bomb.DestroyedEvent;
        }
    }

    #endregion

    #region BombManagerIfc Members

    public Vector2Int? GetRandomBomb() {
        if (m_activeBombs.Count <= 0) {
            return null;
        }
        else if (m_activeBombs.Count == 1) {
            return m_activeBombs[0];
        }
        else {
            int index = (int)(Random.value * m_activeBombs.Count);
            if (m_activeBombs.Count >= index) {
                return GetRandomBomb();
            }
            else {
                return m_activeBombs[index];
            }
        }
    }

    public bool IsBombHere(Vector2Int position) {
        return m_activeBombs.Contains(position);
    }

    #endregion

    #region Private Methods

    private void OnBombDestroyed(Vector2Int position) {
        if (m_activeBombs.Contains(position)) {
            m_activeBombs.Remove(position);
        }
    }

    private void Awake() {
        m_activeBombs = new List<Vector2Int>();
    }

    #endregion

    #region Private Fields

    private List<Vector2Int> m_activeBombs;
    [SerializeField]
    Bomb m_bombPrefab;

    #endregion
}