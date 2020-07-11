using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueRotation : MonoBehaviour
{
    public float AngleSpeed = 45f;
    public float AngularDrag = 1f;
    //[SerializeField] private Space RotationSpace = 0;
    [SerializeField] private Vector2 _rotationDirection = Vector2.zero;
    [SerializeField] private ForceMode _forceMode = ForceMode.Acceleration;
    [SerializeField] private bool IsRelativeRotation = false;

    private TerrainActions _inputActions;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputActions = new TerrainActions();

        _inputActions.gameplay.Rotate.performed += OnRotation;
        _inputActions.gameplay.Rotate.canceled += OnRotationCanceled;
    }

    private void OnRotationCanceled(UnityEngine.InputSystem.InputAction.CallbackContext ctx) => _rotationDirection = Vector2.zero;

    private void OnRotation(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        _rotationDirection = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 angleRotation = Mathf.Abs(_rotationDirection.x) > Mathf.Abs(_rotationDirection.y) ? new Vector3(0, 0, -_rotationDirection.x) : new Vector3(_rotationDirection.y, 0, 0);
        angleRotation *= Time.deltaTime * AngleSpeed;
        if (IsRelativeRotation)
        {
            _rigidbody.AddRelativeTorque(angleRotation, _forceMode);
        }
        else
        {
            _rigidbody.AddTorque(angleRotation, _forceMode);
        }
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _rigidbody.angularDrag = AngularDrag;
        _rigidbody.isKinematic = false;
    }
    private void OnDisable() => _inputActions.Disable();
}
