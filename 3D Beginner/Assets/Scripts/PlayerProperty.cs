using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperty : MonoBehaviour
{
    public GameEnding gameEnding;
    public Slider playerSlider;
    public float MAXHEALTH;

    private float m_PlayerHealth;

    private void Awake()
    {
        m_PlayerHealth = MAXHEALTH;
    }

    public float GetPlayerHealth ()
    {
        return m_PlayerHealth;
    }

    /// <summary>
    /// Change player's hit points by changeValue
    /// </summary>
    /// <param name="changeValue">position and negative is needed</param>
    public void ChangePlayerHealth (float changeValue)
    {
        if (0 == changeValue)
        {
            return;
        }
        m_PlayerHealth += changeValue;
        if (m_PlayerHealth <= 0)
        {
            gameEnding.CaughtPlayer();
            m_PlayerHealth = MAXHEALTH;
        }
        playerSlider.value = m_PlayerHealth;
    }
}
