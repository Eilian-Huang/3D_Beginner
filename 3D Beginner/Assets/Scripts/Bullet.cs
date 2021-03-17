using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool m_IsHit;
    private bool m_IsHitEnemy;
    private string m_EnemyName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Gargoyle" || other.tag == "Ghost")
        {
            m_IsHitEnemy = true;
            m_EnemyName = other.name;
        }
        m_IsHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_EnemyName);
        if (m_IsHitEnemy)
        {
            GameObject.Find(m_EnemyName).GetComponent<EnemyProperty>().ChangeEnemyHealth(-1);
            m_IsHitEnemy = false;
        }
        if (m_IsHit)
        {
            Destroy(transform.gameObject);
        }
    }
}
