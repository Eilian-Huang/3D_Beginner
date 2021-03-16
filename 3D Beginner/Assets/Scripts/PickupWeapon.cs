using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public GameObject player;
    public GameObject box;

    private bool m_IsPlayerInRange;
    private bool m_IsPickupWeapon = false;
    private bool m_IsBoxOpen;

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
        m_IsBoxOpen = box.GetComponent<AnnoBox>().IsBoxOpen();
        if (m_IsPlayerInRange && m_IsBoxOpen && Input.GetKeyDown(KeyCode.E))
        {
            player.GetComponent<PlayerProperty>().SetWeaponSystem();
            box.transform.GetChild(3).gameObject.SetActive(false);
            m_IsPickupWeapon = true;
        }
    }

    void OnGUI()
    {
        if (m_IsPlayerInRange && m_IsBoxOpen && !m_IsPickupWeapon)
        {
            GUI.Box(new Rect(440, 120, 100, 24), "按E拾取");
        }
    }
}
