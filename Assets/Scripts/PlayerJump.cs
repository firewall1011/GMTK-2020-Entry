using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public enum GroundDetectionMode
    {
        Raycast,
        SphereCast
    }

    public bool IsGrounded { get; set; }

    public float JumpForce = 10f;
    public float MaxDistance = 0.5f;
    public float Radius = 0.5f;
    public GroundDetectionMode GroundDetection = 0;


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
        RaycastHit hit = new RaycastHit();
        Ray detectionRay = new Ray(transform.position, Vector3.down);

        switch (GroundDetection)
        {
            case GroundDetectionMode.Raycast:
                IsGrounded = Physics.Raycast(detectionRay, out hit, MaxDistance);
                break;

            case GroundDetectionMode.SphereCast:
                IsGrounded = Physics.SphereCast(detectionRay, Radius, out hit, MaxDistance);
                break;
        }
    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        

        //Check if there has been a hit yet
        if (IsGrounded)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawRay(transform.position, Vector3.down * MaxDistance);
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
