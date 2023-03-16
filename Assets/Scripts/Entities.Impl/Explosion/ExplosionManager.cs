using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour, ExplosionManagerIfc {

    private void Explode(BombIfc bomb) {
        Vector2Int bombPosition = bomb.Position.Round();
        if (!m_levelManager.TryExplode(bombPosition)) {
            Explosion explosionCenter = Instantiate(m_explosionPrefab, bombPosition.ToVector3(), Quaternion.identity, gameObject.transform);
            explosionCenter.SubsidedEvent.AddListener(OnExplosionSubsided);
            m_explosionList.Add(explosionCenter);
            foreach (Vector2Int direction in DIRECTIONS) {
                if (!m_levelManager.TryExplode(bombPosition + direction)) {
                    CreateDirectionalExplosion(bombPosition + direction, direction, bomb.Strength - 1);
                    explosionCenter.Directions.Add(direction);
                }
            }
        }
    }

    // Will be called by the BombManager
    public void Add(BombIfc bomb) {
        bomb.ExplodedEvent.AddListener(Explode);
    }

    public bool IsExplosionHere(Vector2Int position) {
        foreach (ExplosionIfc explosion in m_explosionList) {
            if (explosion.Position.Round() == position) {
                return true;
            }
        }
        return false;
    }

    private void Awake() {
        m_levelManager = GetComponentInParent<LevelManagerIfc>();
        m_explosionList = new List<ExplosionIfc>();
    }

    //private void Start() {
    //    Explosion explosionCenter = Instantiate(m_explosionPrefab, new Vector3(0, 3, 0), Quaternion.identity, gameObject.transform);
    //    m_explosionList.Add(explosionCenter); //todo set at 0,3
    //}

    private void CreateDirectionalExplosion(Vector2Int origin, Vector2Int direction, int strength) {
        Explosion explosion = Instantiate(m_explosionPrefab, origin.ToVector3(), Quaternion.identity, gameObject.transform);
        explosion.SubsidedEvent.AddListener(OnExplosionSubsided);
        m_explosionList.Add(explosion);
        if (strength > 0 && !m_levelManager.TryExplode(origin + direction)) {
            CreateDirectionalExplosion(origin + direction, direction, strength - 1);
            explosion.Directions.Add(direction);
        }
        explosion.Directions.Add(-direction);
    }

    private void OnExplosionSubsided(ExplosionIfc explosion) {
        if (m_explosionList.Contains(explosion)) {
            m_explosionList.Remove(explosion);
        }
        else {
            // Something went wrong. The manager should know all explosions.
        }
    }

    private List<ExplosionIfc> m_explosionList;
    private LevelManagerIfc m_levelManager;
    [SerializeField]
    private Explosion m_explosionPrefab;
    private static readonly Vector2Int[] DIRECTIONS = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
}