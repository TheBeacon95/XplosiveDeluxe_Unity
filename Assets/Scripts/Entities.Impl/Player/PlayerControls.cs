using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControls", menuName = "Player/Controls")]
public class PlayerControls : ScriptableObject {

    #region Public Poperties

    public Vector2Int PressedDirection {
        // Todo for dimi: Make it so that the next direction is only taken if the previous one is not pressed anymore.
        get {
            Vector2Int direction = Vector2Int.zero;
            if (Input.GetKey(m_inputUp)) {
                direction = Vector2Int.up;
            }
            else if (Input.GetKey(m_inputDown)) {
                direction = Vector2Int.down;
            }
            else if (Input.GetKey(m_inputLeft)) {
                direction = Vector2Int.left;
            }
            else if (Input.GetKey(m_inputRight)) {
                direction = Vector2Int.right;
            }
            return direction;
        }
    }

    public bool IsFirePressed {
        get {
            return Input.GetKey(m_inputFire);
        }
    }

    #endregion

    #region Private Fields

    [SerializeField]
    private KeyCode m_inputUp;
    [SerializeField]
    private KeyCode m_inputDown;
    [SerializeField]
    private KeyCode m_inputLeft;
    [SerializeField]
    private KeyCode m_inputRight;
    [SerializeField]
    private KeyCode m_inputFire;

    #endregion
}