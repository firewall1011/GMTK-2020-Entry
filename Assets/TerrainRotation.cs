using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainRotation : MonoBehaviour
{
    public float AngleSpeed = 45f;
    [SerializeField] private Vector2 _rotationDirection;

    private TerrainActions _inputActions;

    private void Awake()
    {
        _inputActions = new TerrainActions();

        _inputActions.gameplay.Rotate.performed += OnRotation;
        _inputActions.gameplay.Rotate.canceled += OnRotationCanceled;
    }

    private void OnRotationCanceled(UnityEngine.InputSystem.InputAction.CallbackContext ctx) => _rotationDirection = Vector2.zero;

    private void OnRotation(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        _rotationDirection = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector3 angleRotation = new Vector3(_rotationDirection.y, 0, -_rotationDirection.x) * Time.deltaTime * AngleSpeed;
        transform.Rotate(angleRotation);
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();
}
