using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputHandler : MonoBehaviour
{
    private float xInput;

    private IMovable movable;
    private IJumpable jumpable;
    private IDashable dashable;
    private IAttackable attackable;

    void Start()
    {
        movable = GetComponent<IMovable>();
        jumpable = GetComponent<IJumpable>();
        dashable = GetComponent<IDashable>();
        attackable = GetComponent<IAttackable>();
    }

    void Update()
    {
        movable.HandleMovement(xInput);
    }

    public void OnMovePerformed(InputAction.CallbackContext callback)
    {
        xInput = callback.ReadValue<Vector2>().x;
    }

    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        jumpable.HandleJump();
    }

    public void OnDashPerformed(InputAction.CallbackContext context)
    {
        dashable.HandleDash();
    }

    public void OnAttackPerformed(InputAction.CallbackContext context)
    {
        attackable.HandleAttack();
    }
}
