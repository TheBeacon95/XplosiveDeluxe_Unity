using System;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player/Status")]
public class PlayerStatus : ScriptableObject {

    #region Public Properties

    public int Lives {
        get {
            return m_lives;
        }
        private set {
            if (value < MIN_LIVES) {
                m_lives = MIN_LIVES;
            }
            else if (value > MAX_LIVES) {
                m_lives = MAX_LIVES;
            }
            else {
                m_lives = value;
            }
        }
    }

    [Reset(DEFAULT_BOMB_STRENGTH)]
    public int BombStrength {
        get {
            return m_bombStrength;
        }
        private set {
            if (value < MIN_BOMB_STRENGTH) {
                m_bombStrength = MIN_BOMB_STRENGTH;
            }
            else if (value > MAX_BOMB_STRENGTH) {
                m_bombStrength = MAX_BOMB_STRENGTH;
            }
            else {
                m_bombStrength = value;
            }
        }
    }

    [Reset(DEFAULT_BOMB_COUNT)]
    public int BombCount {
        get {
            return m_bombCount;
        }
        private set {
            if (value < MIN_BOMB_COUNT) {
                m_bombCount = MIN_BOMB_COUNT;
            }
            else if (value > MAX_BOMB_COUNT) {
                m_bombCount = MAX_BOMB_COUNT;
            }
            else {
                m_bombCount = value;
            }
        }
    }

    [Reset((int)DEFAULT_SPEED)]
    public int Speed { //Todo: make EntitySpeed
        get {
            return (int)m_speed;
        }
        private set {
            if (Enum.IsDefined(typeof(EntitySpeed), value)) {
                m_speed = (EntitySpeed)value;
            }
        }
    }

    public bool HasShieldEffect {
        get {
            return m_effect == PlayerEffect.Shield;
        }
    }

    public bool HasSlowEffect {
        get {
            return m_effect == PlayerEffect.Slow;
        }
    }

    public bool HasGhostEffect {
        get {
            return m_effect == PlayerEffect.Ghost;
        }
    }

    public bool HasNauseaEffect {
        get {
            return m_effect == PlayerEffect.Nausea;
        }
    }

    public bool HasBrickMakerEffect {
        get {
            return m_effect == PlayerEffect.BrickMaker;
        }
    }

    public bool HasBombCrazyEffect {
        get {
            return m_effect == PlayerEffect.BombCrazy;
        }
    }

    public bool HasFirePowerEffect {
        get {
            return m_effect == PlayerEffect.FirePower;
        }
    }

    #endregion

    #region Public Methods

    public void IncreaseBombCount() {
        BombCount++;
    }

    public void IncreaseBombStrength() {
        BombStrength++;
    }

    public void IncreaseLifeCount() {
        Lives++;
    }

    public void IncreaseSpeed() {
        Speed++;
    }

    public void SetBombCraze() {
        m_effect = PlayerEffect.BombCrazy;
    }

    public void SetBrickMaker() {
        m_effect = PlayerEffect.BrickMaker;
    }

    public void SetFirePower() {
        m_effect = PlayerEffect.FirePower;
    }

    public void SetGhost() {
        m_effect = PlayerEffect.Ghost;
    }

    public void SetNausea() {
        m_effect = PlayerEffect.Nausea;
    }

    public void SetShield() {
        m_effect = PlayerEffect.Shield;
    }

    public void SetSlow() {
        m_effect = PlayerEffect.BombCrazy;
    }

    public void MinimiseBombStrength() {
        m_bombStrength = MIN_BOMB_STRENGTH;
    }

    public void ResetEffect() {
        m_effect = PlayerEffect.None;
    }

    public void Reset() {
        Type myType = GetType();
        foreach (PropertyInfo property in myType.GetProperties()) {
            if (property.GetCustomAttribute<ResetAttribute>() == null) {
                continue;
            }
            else {
                ResetAttribute attribute = Attribute.GetCustomAttribute(property, typeof(ResetAttribute)) as ResetAttribute;
                property.SetValue(this, attribute.ResetValue);
            }
        }
    }

    #endregion

    #region Private Fields

    private PlayerEffect m_effect; // TODO: Make resettable property.

    // Bomb Strength
    [SerializeField]
    private int m_bombStrength;
    private const int DEFAULT_BOMB_STRENGTH = 2;
    private const int MIN_BOMB_STRENGTH = 1;
    private const int MAX_BOMB_STRENGTH = 8;

    // Bomb Count
    [SerializeField]
    private int m_bombCount;
    private const int DEFAULT_BOMB_COUNT = 1;
    private const int MIN_BOMB_COUNT = 1;
    private const int MAX_BOMB_COUNT = 8;

    // Speed
    [SerializeField]
    private EntitySpeed m_speed;
    private const EntitySpeed DEFAULT_SPEED = EntitySpeed.Fast;

    // Speed
    [SerializeField]
    private int m_lives;
    private const int MIN_LIVES = 0;
    private const int MAX_LIVES = 10;

    private class ResetAttribute : Attribute {
        public ResetAttribute(int resetValue) {
            ResetValue = resetValue;
        }

        public int ResetValue {
            get;
        }
    }

    #endregion
}