using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public float rebornTime = 3f;
    public float rebornTimeAfterLightOff;
    public float notAttackTimeAfterReborn;
    public GameObject ghost;

    private bool m_IsLightOff;
    private bool m_IsGhostDieByLight;
    private bool m_IsGhostDie;
    private float m_Timer;
    private GameObject m_Light;

    public void GhostDieReborn()
    {
        ghost.SetActive(false);
        m_IsGhostDie = true;
    }

    public void GhostDieReborn (GameObject light)
    {
        // Ghost dies
        ghost.SetActive(false);
        m_IsGhostDieByLight = true;
        m_Light = GameObject.Find(light.name);
    }

    private void Update()
    {
        if (m_IsGhostDieByLight)
        {
            if (m_Light != null)
            {
                m_IsLightOff = !m_Light.activeInHierarchy;
            }
            // Ghost will reborn only if light is off
            if (m_IsLightOff)
            {
                m_Timer += Time.deltaTime;
                // Ghost will reborn when light is off for "rebornTimeAfterLightOff" seconds
                if (m_Timer >= rebornTimeAfterLightOff)
                {
                    ghost.SetActive(true);
                    ghost.transform.GetChild(2).gameObject.SetActive(false);
                    m_Timer = 0;
                    m_IsGhostDieByLight = false;
                }
                if (m_Timer >= notAttackTimeAfterReborn)
                {
                    ghost.transform.GetChild(2).gameObject.SetActive(true);
                    m_Timer = 0;
                }
            }
        }
        if (m_IsGhostDie)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= rebornTime)
            {
                ghost.SetActive(true);
                ghost.transform.GetChild(2).gameObject.SetActive(false);
                m_Timer = 0;
                m_IsGhostDie = false;
            }
            if (m_Timer >= notAttackTimeAfterReborn)
            {
                ghost.transform.GetChild(2).gameObject.SetActive(true);
                m_Timer = 0;
            }
        }
    }
}
