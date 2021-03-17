using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleControl : MonoBehaviour
{
    public float rebornTime = 3f;
    public float notAttackTimeAfterReborn = 3f;
    public GameObject gargoyle;

    private bool m_IsGargoyleDie;
    private float m_Timer;

    public void GargoyleDieReborn(string name)
    {
        gargoyle.SetActive(false);
        m_IsGargoyleDie = true;
    }

    private void Update()
    {
        if (m_IsGargoyleDie)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= rebornTime)
            {
                gargoyle.SetActive(true);
                gargoyle.transform.GetChild(1).gameObject.SetActive(false);
                StartCoroutine("GargoyleNotAttack");
                m_Timer = 0;
                m_IsGargoyleDie = false;
            }
        }
    }

    IEnumerator GargoyleNotAttack()
    {
        yield return new WaitForSeconds(3f);
        gargoyle.transform.GetChild(1).gameObject.SetActive(true);
    }
}
