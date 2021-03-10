using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    public GameObject ghost;
    public GameObject light;
    public float rebornTime;
    
    private bool m_IsGhostInRange;
    private bool m_IsGhost;
    private float m_Timer = 0.0f;

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == ghost.transform)
        {
            m_IsGhostInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == ghost.transform)
        {
            m_IsGhostInRange = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (m_IsGhostInRange)
        {
            Vector3 direction = ghost.transform.position - transform.position + Vector3.up;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == ghost.transform)
                {
                    //Destroy(ghost);
                    m_IsGhost = false;
                }
            }
        }
        if (!light.activeInHierarchy)
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= rebornTime && !m_IsGhost)
            {
                //Instantiate(ghost);
                m_IsGhost = true;
            }
        }
    }
}