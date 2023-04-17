using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControls", menuName = "Player/Controls")]
public class PlayerControls : ScriptableObject {

    #region Public Poperties

    public Vector2Int PressedDirection {
        // Todo for dimi: Make it so that the next direction is only taken if the previous one is not pressed anymore.
        get {
            return GetDirection();
        }
    }

    public bool IsFirePressed {
        get {
            return Input.GetKey(m_inputFire);
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Returns the direction the player wants to move in.
    /// Note: When multiple directions are pressed, the direction that was pressed second has priority.
    /// </summary>
    /// <returns>Direction the player wants to move in.</returns>
    private Vector2Int GetDirection() {
        Vector2Int direction = Vector2Int.zero;
        List<Vector2Int> currentlyPressedDirections = new List<Vector2Int>();
        if (Input.GetKey(m_inputUp)) {
            currentlyPressedDirections.Add(Vector2Int.up);
        }
        if (Input.GetKey(m_inputRight)) {
            currentlyPressedDirections.Add(Vector2Int.right);
        }
        if (Input.GetKey(m_inputDown)) {
            currentlyPressedDirections.Add(Vector2Int.down);
        }
        if (Input.GetKey(m_inputLeft)) {
            currentlyPressedDirections.Add(Vector2Int.left);
        }

        if (currentlyPressedDirections.Count < 1) {
            // Do nothing.
            m_lastDirection = Vector2Int.zero;
        }
        else if (currentlyPressedDirections.Count == 1) {
            direction = currentlyPressedDirections[0];
            m_lastDirection = direction;
        }
        else {
            foreach (Vector2Int currentlyPressedDirection in currentlyPressedDirections) {
                if (currentlyPressedDirection != m_lastDirection) {
                    direction = currentlyPressedDirection;
                    break;
                }
            }
        }

        
        return direction;
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private KeyCode m_inputUp;
    [SerializeField]
    private KeyCode m_inputRight;
    [SerializeField]
    private KeyCode m_inputDown;
    [SerializeField]
    private KeyCode m_inputLeft;
    [SerializeField]
    private KeyCode m_inputFire;

    private Vector2Int m_lastDirection;
    private static ReadOnlyCollection<Vector2Int> s_directions = (new List<Vector2Int>() { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left }).AsReadOnly();

    #endregion
}