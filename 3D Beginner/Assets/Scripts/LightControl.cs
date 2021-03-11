using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject light;
    public float lightOnTimer;
    public float lightOffTimer;

    private float m_Timer = 0.0f;
    private bool isLightOn = true;

    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer >= lightOnTimer && isLightOn)
        {
            light.SetActive(false);
            isLightOn = false;
            m_Timer = 0;
        }
        if (m_Timer >= lightOffTimer && !isLightOn)
        {
            light.SetActive(true);
            isLightOn = true;
            m_Timer = 0;
        }
    }
}
