using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool m_IsHit;
    private bool m_IsHitEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gargoyle" || other.tag == "Ghost")
        {
            m_IsHitEnemy = true;
        }
        m_IsHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsHitEnemy)
        {
            Debug.Log("Hit!");
        }
        if (m_IsHit)
        {
            Destroy(transform.gameObject);
        }
    }
}
