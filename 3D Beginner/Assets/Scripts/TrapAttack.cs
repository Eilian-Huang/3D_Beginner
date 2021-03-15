using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    public GameObject player;

    private bool m_IsPlayerInRange;
    private bool m_IsPlayerDamaged;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform);
        Debug.Log(player.transform);
        // m_IsPlayerInRange is true only if JohnLemon is in range
        if (other.transform == player.transform)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player.transform)
        {
            m_IsPlayerInRange = false;
            m_IsPlayerDamaged = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange && !m_IsPlayerDamaged)
        {
            int m_RandomNumber = Random.Range(-10, 10);
            if (m_RandomNumber >=0)
            {
                player.GetComponent<PlayerProperty>().ChangePlayerSpeed(0.5f, 5f);
            }
            else if (m_RandomNumber < 0)
            {
                player.GetComponent<PlayerProperty>().ChangePlayerHealth(-1);
            }
            m_IsPlayerDamaged = true;
        }
    }
}
