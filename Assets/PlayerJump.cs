using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool IsGrounded { get; set; }

    public float JumpForce = 10f;
    public float MaxDistance = 0.5f;
    

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnJump()
    {
        if (IsGrounded)
        {
            Vector3 jumpDir = Vector3.up * JumpForce;
            _rigidbody.AddForce(jumpDir, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        //Test to see if there is a hit using a BoxCast
        //Also fetch the hit data
        RaycastHit hit;

        IsGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, MaxDistance);
        if (IsGrounded)
        {
            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + hit.collider.name);
        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        

        //Check if there has been a hit yet
        if (IsGrounded)
        {
            Gizmos.color = Color.green;
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, Vector3.down * MaxDistance);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            Gizmos.color = Color.red;
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, Vector3.down * MaxDistance);
        }
    }
}
