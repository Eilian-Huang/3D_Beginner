using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnoBox : MonoBehaviour
{
    public GameObject player;

    private Animator m_Animator;
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

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            transform.GetChild(1).Rotate(-90, 0, 0);
            player.GetComponent<PlayerProperty>().SetWeaponSystem();
            m_IsBoxOpen = true;
        }
    }

    void OnGUI()
    {
        if (m_IsPlayerInRange && !m_IsBoxOpen)
        {
            GUI.Box(new Rect(440, 120, 100, 24), "按F打开");
        }
    }
}
