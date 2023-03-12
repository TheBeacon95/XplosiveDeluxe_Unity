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

    #endregion

    #region Public Properties

    public abstract SpriteHandlerAbs SpriteHandler {
        get;
    }

    public virtual bool IsMoving {
        get;
        protected set;
    }

    #endregion

    #region Protected Methods

    protected IEnumerator Move(Vector2 direction, int speed) {
        IsMoving = true;
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
        IsMoving = false;
    }

    #endregion
}