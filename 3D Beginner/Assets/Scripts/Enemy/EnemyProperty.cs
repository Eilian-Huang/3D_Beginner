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

    /// <summary>
    /// Change enemy hit points by changeValue
    /// </summary>
    /// <param name="changeValue">position and negative is needed</param>
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

    /// <summary>
    /// Overloaded when ghost is hurt by light
    /// </summary>
    /// <param name="lights"></param>
    private void EnemyDieOperation (GameObject lights)
    {
        ghostControl.GhostDieReborn(lights);
        m_EnemyHealth = MAXHEALTH;
    }
}
