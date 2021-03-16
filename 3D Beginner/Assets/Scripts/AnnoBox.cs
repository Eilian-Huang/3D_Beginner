using System.Collections;
using UnityEngine;

public class AnnoBox : MonoBehaviour
{
    public GameObject player;

    private bool m_IsPlayerInRange;
    private bool m_IsBoxOpen = false;

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
        if (m_IsPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            transform.GetChild(1).Rotate(-90, 0, 0);
            m_IsBoxOpen = true;
            StartCoroutine("Appear");
            transform.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator Appear()
    {
        for (int count = 60; count >= 0; count --)
        {
            GameObject.Find("M1911").transform.position += new Vector3(0, 0.01f, 0);
            yield return null;
        }
    }

    void OnGUI()
    {
        if (m_IsPlayerInRange && !m_IsBoxOpen)
        {
            GUI.Box(new Rect(440, 120, 100, 24), "按F打开");
        }
    }

    public bool IsBoxOpen()
    {
        return m_IsBoxOpen;
    }
}
