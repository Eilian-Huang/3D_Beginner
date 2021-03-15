using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject light;
    public float lightOnTimer;
    public float lightOffTimer;

    private float m_Timer = 0.0f;
    private bool isLightOn = true;
    private GameObject Background;
    private bool m_IsPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "JohnLemon")
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "JohnLemon")
        {
            m_IsPlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            light.SetActive(!isLightOn);
            isLightOn = !isLightOn;
            m_Timer = 0;
        }
            m_Timer += Time.deltaTime;
        // Turn lights off when it's on for "LightOnTimer" seconds
        if (m_Timer >= lightOnTimer && isLightOn)
        {
            light.SetActive(false);
            isLightOn = false;
            m_Timer = 0;
        }
        // Turn lights on when it's off for "LightOffTimer" seconds
        if (m_Timer >= lightOffTimer && !isLightOn)
        {
            light.SetActive(true);
            isLightOn = true;
            m_Timer = 0;
        }
    }

    void OnGUI()
    {
        if (m_IsPlayerInRange)
        {
            GUI.Box(new Rect(440, 120, 100, 24), "按E开关灯");
        }
    }
}
