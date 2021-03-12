using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    public GameObject player;

    private bool m_IsPlayerInRange;
    private bool m_IsPlayerDamaged;

    private void OnTriggerEnter(Collider other)
    {
        // m_IsPlayerInRange is true only if JohnLemon is in range
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
            m_IsPlayerDamaged = false;
        }
    }

    private void Update()
    {
        if (m_IsPlayerInRange && !m_IsPlayerDamaged)
        {
            player.gameObject.GetComponent<PlayerProperty>().ChangePlayerHealth(-1);
            m_IsPlayerDamaged = true;
        }
    }
}
