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
    private ISlidable slidable;
    private IAttackable attackable;

    void Start()
    {
        movable = GetComponent<IMovable>();
        jumpable = GetComponent<IJumpable>();
        dashable = GetComponent<IDashable>();
        slidable = GetComponent<ISlidable>();
        attackable = GetComponent<IAttackable>();
    }

    void Update()
    {
        if (!dashable.IsDashing() && !slidable.IsSliding())
        {
            movable.HandleMovement(xInput, false);
        }
    }

    public void OnMovePerformed(InputAction.CallbackContext callback)
    {
        xInput = callback.ReadValue<Vector2>().x;
    }

    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !slidable.IsSliding())
        {
            jumpable.HandleJump();
        }
    }

    public void OnDashPerformed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !slidable.IsSliding())
        {
            dashable.HandleDash();
            movable.HandleMovement(0, true);
        }
    }

    public void OnSlidePerformed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !jumpable.IsFalling())
        {
            slidable.HandleSlide();
            movable.HandleMovement(0, true);
        }
    }

    public void OnAttackPerformed(InputAction.CallbackContext context)
    {
        attackable.HandleAttack();
    }
}
