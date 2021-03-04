using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // radians that character rotates per second
    public float turnSpeed = 20f;
    // Reference of Animator component
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    // Vector of 3D space
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        // Set reference of Animator
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Variate of horizontal axis
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");

        // Set value (x_axis, y_axis, z_axis)
        m_Movement.Set(horizontal, 0f, vertical);
        /* Nomalization:
         * keep the direction of the vector the same, but change its magnitude to 1
         */
        m_Movement.Normalize ();

        // hasHorizontalInput is true only if horizontal is not approximate to 0
        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        // OR operator
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool ("IsWalking", isWalking);
        // Compute the forward vector of the character 
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, 
            turnSpeed * Time.deltaTime, 0f);
        // Create a rotation in the direction of the given parameters
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    // Apply root motion as needed
    void OnAnimatorMove ()
    {
        // Movement
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement 
            * m_Animator.deltaPosition.magnitude);
        // Rotation
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}
