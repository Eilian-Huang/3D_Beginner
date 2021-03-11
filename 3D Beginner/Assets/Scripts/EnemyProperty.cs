using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperty : MonoBehaviour
{
    public float MAXHEALTH;
    public GhostControl ghostControl;

    private float m_EnemyHealth;

    private void Awake()
    {
        m_EnemyHealth = MAXHEALTH;
    }

    public float GetEnemyHealth ()
    {
        return m_EnemyHealth;
    }

    public void ChangeEnemyHealth (float changeValue)
    {
        if (0 == changeValue)
        {
            return;
        }
        m_EnemyHealth += changeValue;
        if (m_EnemyHealth <= 0)
        {
            EnemyDieOperation();
        }
    }

    public void ChangeEnemyHealth (float changeValue, GameObject lights)
    {
        if (0 == changeValue)
        {
            return;
        }
        m_EnemyHealth += changeValue;
        if (m_EnemyHealth <= 0)
        {
            EnemyDieOperation(lights);
        }
    }

    private void EnemyDieOperation ()
    {
    }

    private void EnemyDieOperation (GameObject lights)
    {
        ghostControl.GhostDieReborn(transform.gameObject, lights);
        m_EnemyHealth = MAXHEALTH;
    }
}
