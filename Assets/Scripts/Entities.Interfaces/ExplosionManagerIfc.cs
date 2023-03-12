using UnityEngine;

public interface ExplosionManagerIfc {

    // Todo: Explain
    void Add(BombIfc bomb);

    // Todo: Explain
    bool IsExplosionHere(Vector2Int position);

}