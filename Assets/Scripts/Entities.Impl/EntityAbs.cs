using System.Collections;
using UnityEngine;

public abstract class EntityAbs : MonoBehaviour, EntityIfc {

    #region EntityIfc Members

    public virtual Vector2 Position {
        get {
            return gameObject.transform.position.ToVector2();
        }
    }

    public virtual Vector2Int Direction {
        get {
            return Vector2Int.zero;
        }
    }

    public virtual bool IsIdle {
        get {
            return m_isIdle;
        }
        protected set {
            m_isIdle = value;
        }
    }

    public virtual bool IsStalled {
        get {
            return false;
        }
        set {
            // Do nothing.
        }
    }

    #endregion

    #region Public Properties

    public abstract SpriteHandlerAbs SpriteHandler {
        get;
    }

    #endregion

    #region Public Methods

    public IEnumerator Move(Vector2 direction, int speed) {
        m_isMoving = true;
        float timeToMove = 1f / speed / 8;
        float elapsedTime = 0f;
        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = originalPosition + direction / 8;

        while (elapsedTime < timeToMove) {
            transform.position = Vector2.Lerp(originalPosition, targetPosition, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        m_isMoving = false;
    }

    #endregion

    #region Protected Fields

    protected bool m_isMoving;

    #endregion

    #region Private Fields

    private bool m_isIdle = true;

    #endregion
}