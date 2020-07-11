using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftMaterial : MonoBehaviour
{
    [SerializeField] private ShapeMaterialSO material = null;

    private Rigidbody _rigidbody;
    private PlayerJump _playerJump;

    private void Awake()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
        _playerJump = GetComponentInParent<PlayerJump>();
        GetComponent<Collider>().material = material.physicMaterial;
    }

    private void OnEnable()
    {
        //Physics properties
        _rigidbody.mass = material.mass;

        //Jump Properties
        _playerJump.JumpForce = material.JumpForce;
        _playerJump.MaxDistance = material.MaxDistance;
        _playerJump.Radius = material.Radius;
        _playerJump.GroundDetection = material.GroundDetection;
    }
}
