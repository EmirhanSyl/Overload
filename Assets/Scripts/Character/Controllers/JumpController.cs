using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour, IJumpable
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float fallingOffset = 0.1f;

    private int jumpCount;

    private bool isJumping;
    private bool isFalling;
    private bool canDoubleJump;
    private bool isGrounded;

    [SerializeField] private GroundChecker groundChecker;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = groundChecker.IsGrounded;

        isJumping = (rb.velocity.y > 0 + fallingOffset) ? true : false;
        isFalling = (rb.velocity.y < 0 - fallingOffset) ? true : false;
    }

    public void HandleJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canDoubleJump = true;
            jumpCount = 1;
        }
        else if (canDoubleJump && jumpCount < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            canDoubleJump = false;
        }
    }

    public bool IsJumping()
    {
        return isJumping;
    }

    public bool IsFalling()
    {
        return isFalling;
    }
}
