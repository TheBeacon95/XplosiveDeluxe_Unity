using UnityEngine;

public abstract class MonsterMovementAbs : ScriptableObject {

    public void Setup(Rigidbody2D self, LevelManagerIfc levelManager) {
        m_self = self;
        m_levelManager = levelManager;
    }

    /// <Summary>
    /// Moves the Monster by one increment. This method is called periodically.
    ///...
    protected abstract Vector2Int Move();

    protected Rigidbody2D m_self;
    protected LevelManagerIfc m_levelManager;


}