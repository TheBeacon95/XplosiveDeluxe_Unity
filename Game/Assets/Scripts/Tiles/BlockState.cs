/// <summary>
/// Todo
/// </summary>
public class BlockState {

    #region Public Properties

    public bool IsOn {
        get {
            return m_state == OnOffState.On;
        }
    }

    public bool IsOff {
        get {
            return m_state != OnOffState.On;
        }
    }

    #endregion

    #region Private Fields

    private enum OnOffState {
        Undefined = 0,
        On = 1,
        Off = 2
    }

    private OnOffState m_state;

    #endregion

}