using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour
{
    public float rebornTimeAfterLightOff;
    public float notAttackTimeAfterReborn;
    public GameObject ghost;

    private bool isLightOff;
    private bool isGhostDie;
    private float m_Timer;
    private GameObject m_Light;

    public void GhostDieReborn (GameObject light)
    {
        // Ghost dies
        ghost.SetActive(false);
        isGhostDie = true;
        m_Light = GameObject.Find(light.name);
    }

    private void Update()
    {
        if (m_Light != null)
        {
            isLightOff = !m_Light.activeInHierarchy;
        }
        // Ghost will reborn only if light is off
        if (isLightOff)
        {
            m_Timer += Time.deltaTime;
            // Ghost will reborn when light is off for "rebornTimeAfterLightOff" seconds
            if (m_Timer >= rebornTimeAfterLightOff && isLightOff && isGhostDie)
            {
                ghost.SetActive(true);
                ghost.transform.GetChild(2).gameObject.SetActive(false);
                isGhostDie = false;
                m_Timer = 0;
            }
            // Ghost won't attack player for "NotAttackTimeAfterReborn" seconds after it's reborn
            if (!isGhostDie && m_Timer >= notAttackTimeAfterReborn)
            {
                ghost.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
}
