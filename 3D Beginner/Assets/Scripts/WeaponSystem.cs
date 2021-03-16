using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrelLocation;
    public int bulletCount = 3;
    public float fireRate = 1.0f;
    public float bulletSpeed = 50f;

    private float m_NextFireTimer;
    private bool m_IsActive;
    private bool m_Shoot;

    public void Active()
    {
        transform.GetChild(4).gameObject.SetActive(true);
        m_IsActive = true;
    }

    private void InActive()
    {
        transform.GetChild(4).gameObject.SetActive(false);
        transform.gameObject.GetComponent<PlayerProperty>().CloseWeaponSystem();
        m_IsActive = false;
    }

    private void Update()
    {
        m_NextFireTimer += Time.fixedDeltaTime;
        if (m_IsActive && Input.GetMouseButton(0) && m_NextFireTimer > fireRate)
        {
            m_NextFireTimer = 0;
            m_Shoot = true;
            bulletCount--;
        }
        if (m_Shoot)
        {
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).
                GetComponent<Rigidbody>().AddForce(barrelLocation.forward * bulletSpeed);
            m_Shoot = false;
        }
        if (bulletCount == 0)
        {
            InActive();
        }
    }
}
