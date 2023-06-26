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
    private IRollable rollable;
    private IWallSlidable wallSlidable;
    private IAttackable attackable;

    void Start()
    {
        movable = GetComponent<IMovable>();
        jumpable = GetComponent<IJumpable>();
        dashable = GetComponent<IDashable>();
        slidable = GetComponent<ISlidable>();
        attackable = GetComponent<IAttackable>();
        rollable = GetComponent<IRollable>();
        wallSlidable = GetComponent<IWallSlidable>();
    }

    void Update()
    {
        if (!dashable.IsDashing() && !slidable.IsSliding() && !rollable.IsRolling())
        {
            movable.HandleMovement(xInput);
        }
    }

    public void OnMovePerformed(InputAction.CallbackContext callback)
    {
        xInput = callback.ReadValue<Vector2>().x;
    }

    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !slidable.IsSliding() && !rollable.IsRolling())
        {
            jumpable.HandleJump();
        }
    }

    public void OnDashPerformed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !slidable.IsSliding() && !rollable.IsRolling())
        {
            dashable.HandleDash();
            movable.HandleMovement(0, true);
        }
    }

    public void OnSlidePerformed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !jumpable.IsFalling() && !rollable.IsRolling())
        {
            slidable.HandleSlide();
            movable.HandleMovement(0, true);
        }
    }

    public void OnRollPerformed(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !jumpable.IsFalling() && !slidable.IsSliding())
        {
            rollable.HandleRolling();
            movable.HandleMovement(0, true);
        }
    }

    public void OnAttackPerformed(InputAction.CallbackContext context)
    {
        attackable.HandleAttack();
    }
}
