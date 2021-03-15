using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    public GameObject player;

    private GameObject Background;
    private bool m_IsPlayerInRange;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.transform == player.transform)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player.transform)
        {
            m_IsPlayerInRange = false;
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
