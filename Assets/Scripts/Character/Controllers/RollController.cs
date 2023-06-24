using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollController : MonoBehaviour, IRollable
{
    [SerializeField] private float rollSpeed = 10f;
    [SerializeField] private float rollDuration = 0.2f;

    [SerializeField] private float rollCooldown = 2f;

    private int direction;

    private bool isRolling = false;
    private bool canRoll = true;

    private GroundChecker groundChecker;
    private Rigidbody2D rb;
    private SpriteRenderer sRenderer;


    void Awake()
    {
        groundChecker = GetComponentInChildren<GroundChecker>();
        sRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = (sRenderer.flipX) ? -1 : 1;
        if (isRolling)
        {
            rb.velocity = new Vector2(rollSpeed * direction, rb.velocity.y);

            if (!groundChecker.IsGrounded)
            {
                StopCoroutine(RollRoutine());
                isRolling = false;
                canRoll = true;
            }
        }

    }

    public void HandleRolling()
    {
        if (!isRolling && canRoll && groundChecker.IsGrounded)
        {
            StartCoroutine(RollRoutine());
        }
    }
    private IEnumerator RollRoutine()
    {
        isRolling = true;
        canRoll = false;
        yield return new WaitForSeconds(rollDuration);
        isRolling = false;
        yield return new WaitForSeconds(rollCooldown);
        canRoll = true;
    }

    public bool IsRolling()
    {
        return isRolling;
    }
    
}
