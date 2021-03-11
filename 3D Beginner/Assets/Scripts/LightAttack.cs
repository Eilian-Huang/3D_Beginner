using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    public GameObject ghost;
    
    private bool m_IsGhostInRange;

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
                    GameObject.Find("GhostControl").GetComponent < GhostControl > ().GhostDieReborn(ghost, transform.parent.gameObject);
                }
            }
        }
    }
}