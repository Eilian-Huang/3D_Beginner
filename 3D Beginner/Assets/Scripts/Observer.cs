using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : MonoBehaviour
{
    // Reference of JohnLemon's transform
    public Transform player;
    public GameEnding gameEnding;
    public SliderControl SliderControl;

    bool m_IsPlayerInRange;
    bool m_IsPlayerDamaged;

    void OnTriggerEnter (Collider other)
    {
        // m_IsPlayerInRange is true only if JohnLemon is in range
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
            m_IsPlayerDamaged = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        /* Player is damaged only if he is in range
         * And he is not in range last frame
         * This make sure that he will not hurt to death in several frames
         */
        if (m_IsPlayerInRange && !m_IsPlayerDamaged)
        {
            /*
             * Vector from PointOfView to JohnLemon 
             * To make sure that the Observer can see the center of mass of JohnLemon
             * Set the direction to one unit up
             */
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            // Raycast is true when ray hits JohnLemon
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    // Player health - 1
                    float health = SliderControl.GetSliderValue() - 1;
                    if (health <= 0)
                    {
                        gameEnding.CaughtPlayer ();
                    }
                    SliderControl.SetSliderValue (health);
                    m_IsPlayerDamaged = true;
                }
            }
        }
    }
}
