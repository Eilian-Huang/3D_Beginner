using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public float rebornTimeAfterLightOff;
    public float NotAttackTimeAfterReborn;

    private bool isLightOff;
    private bool isGhostDie;
    private float m_Timer;
    private GameObject m_light;
    private GameObject m_ghost;

    public void GhostDieReborn (GameObject ghost, GameObject light)
    {
        // Ghost dies
        ghost.SetActive(false);
        isGhostDie = true;
        m_ghost = ghost;
        m_light = light;
    }

    private void Update()
    {
        isLightOff = !m_light.activeInHierarchy;
        // Ghost will reborn only if light is off
        if (isLightOff)
        {
            m_Timer += Time.deltaTime;
            // Ghost will reborn when light is off for "rebornTimeAfterLightOff" seconds
            if (m_Timer >= rebornTimeAfterLightOff && isLightOff && isGhostDie)
            {
                m_ghost.SetActive(true);
                m_ghost.transform.GetChild(2).gameObject.SetActive(false);
                isGhostDie = false;
                m_Timer = 0;
            }
            // Ghost won't attack player for "NotAttackTimeAfterReborn" seconds after it's reborn
            if (!isGhostDie && m_Timer >= NotAttackTimeAfterReborn)
            {
                m_ghost.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
}
