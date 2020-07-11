using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeMaterialSO : ScriptableObject
{
    [Header("Physics properties")]
    [Range(0.0000001f, 1000000000f)]
    public float mass;
    public PhysicMaterial physicMaterial;

    [Header("Jump properties")]
    public float JumpForce;
    public float MaxDistance;
    public float Radius;
    public PlayerJump.GroundDetectionMode GroundDetection = 0;

}
