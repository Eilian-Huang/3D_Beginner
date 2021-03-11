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
        ghost.SetActive(false);
        isGhostDie = true;
        m_ghost = ghost;
        m_light = light;
    }

    private void Update()
    {
        Debug.Log("ghost: "+m_ghost);
        Debug.Log("light: "+m_light);
        isLightOff = !m_light.activeInHierarchy;
        if (isLightOff)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= rebornTimeAfterLightOff && isLightOff && isGhostDie)
            {
                m_ghost.SetActive(true);
                m_ghost.transform.GetChild(2).gameObject.SetActive(false);
                isGhostDie = false;
                m_Timer = 0;
            }
            if (!isGhostDie && m_Timer >= NotAttackTimeAfterReborn)
            {
                m_ghost.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
}
