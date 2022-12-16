using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, PlayerIfc {

    #region PlayerIfc Members

    public string Name {
        get;
        private set;
    }

    public int Lives {
        get;
        private set;
    }

    public bool IsGhost {
        get;
        private set;
    }

    public Vector2 Position {
        get {
            return transform.position;
        }
    }

    public void DecreaseLife() {
        Lives--;
        if (Lives < 0) {
            Lives = 0;
        }
    }

    public void IncreaseBombCount() {
        if (m_bombCount < MAX_BOMB_COUNT) {
            m_bombCount++;
        }
    }

    public void IncreaseBombLength() {
        if (m_bombLength < MAX_BOMB_LENGTH) {
            m_lifeCount++;
        }
    }

    public void IncreaseLifeCount() {
        if (m_lifeCount < MAX_LIFE_COUNT) {
            m_lifeCount++;
        }
    }

    public void IncreaseSpeed() {
        if (m_speed < MAX_SPEED) {
            m_speed++;
        }
    }

    public void SetBombCraze(float time) {
        ResetAllEffects();
        m_isBombCrazy = true;
        ResetAndStartEffectTimer();
    }

    public void SetBrickMaker() {
        throw new System.NotImplementedException();
    }

    public void SetFirePower(float time) {
        throw new System.NotImplementedException();
    }

    public void SetGhost(float time) {
        throw new System.NotImplementedException();
    }

    public void SetNausea(float time) {
        throw new System.NotImplementedException();
    }

    public void SetShield(float time) {
        throw new System.NotImplementedException();
    }

    public void SetSlow() {
        throw new System.NotImplementedException();
    }

    public void SetStuck(float time) {
        throw new System.NotImplementedException();
    }

    public void SetWeak() {
        throw new System.NotImplementedException();
    }

    public void Teleport(Vector2 newPosition) {
        throw new System.NotImplementedException();
    }

    #endregion

    #region Private Fields


    private int m_bombCount;
    private int m_bombLength;
    private int m_lifeCount;
    private int m_speed;
    private bool m_isBombCrazy;

    // Constants
    private const int MAX_BOMB_COUNT = 8; // Maximum number of bombs a player can have.
    private const int MAX_BOMB_LENGTH = 10; // Maximum length of a bomb.
    private const int MAX_LIFE_COUNT = 10; // Maximum amount of lives a player can have.
    private const int MAX_SPEED = 10; // Maximum speed a player can have.

    private const float DEFAULT_EFFECT_TIME = 10f;
    private readonly YieldInstruction DEFAULT_YIELD_INSTRUCTION = new WaitForSeconds(DEFAULT_EFFECT_TIME);

    #endregion

    #region Private Methods

    private void ResetAndStartEffectTimer() {
        throw new NotImplementedException();
    }

    private void ResetAllEffects() {
        throw new NotImplementedException();
    }

    #endregion
}
