using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour, ExplosionIfc {

    #region Private Methods



    #endregion

    #region Private Fields

    private Collider2D m_collider;

    public bool IsBrickMaker => throw new System.NotImplementedException();

    public int DirectionCount => throw new System.NotImplementedException();

    public Vector2Int Position => throw new System.NotImplementedException();

    public UnityEvent SubsidedEvent => throw new System.NotImplementedException();

    #endregion

}
