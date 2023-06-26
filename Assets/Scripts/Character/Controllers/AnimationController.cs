using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private IMovable movable;
    private IJumpable jumpable;
    private IDashable dashable;
    private ISlidable slidable;
    private IRollable rollable;
    private IWallSlidable wallSlidable;
    private IAttackable attackable;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movable = GetComponent<IMovable>();
        jumpable = GetComponent<IJumpable>();
        dashable = GetComponent<IDashable>();
        slidable = GetComponent<ISlidable>();
        rollable = GetComponent<IRollable>();
        wallSlidable = GetComponent<IWallSlidable>();
        attackable = GetComponent<IAttackable>();
    }

    private void Update()
    {
        animator.SetFloat("MovementSpeed", Mathf.Abs(movable.GetSpeed()));
        animator.SetBool("IsJumping", jumpable.IsJumping());
        animator.SetBool("IsFalling", jumpable.IsFalling());
        animator.SetBool("IsDashing", dashable.IsDashing());
        animator.SetBool("IsSliding", slidable.IsSliding());
        animator.SetBool("IsRolling", rollable.IsRolling());
        animator.SetBool("IsWallSliding", wallSlidable.IsWallSliding());
        //animator.SetBool("IsAttacking", attackable.IsAttacking());
    }
}
