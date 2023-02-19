using System.Collections;
using UnityEngine;

public abstract class EntityAbs : MonoBehaviour {

    #region Public Properties

    public abstract Vector2 Position {
        get;
    }

    public abstract Vector2Int Direction {
        get;
    }

    #endregion

    #region Protected Methods

    protected IEnumerator Move(Vector2 direction, int speed) {
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
}