/// <summary>
/// Defines all types of On/Off blocks.
/// </summary>
public enum StateBlockType {
    None = 0,
    OnBlock,        // Walkable when off, not walkable when on (indestructible).
    OffBlock,       // Walkable when ofn, not walkable when off (indestructible).
    OnSwitch,       // Turns the state to on, when hit by explosion (indestructible).
    OffSwitch,      // Turns the state to off, when hit by explosion (indestructible).
    StateSwitch     // Toggles the state, when hit by explosion (indestructible).
}