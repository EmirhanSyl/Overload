using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideController : MonoBehaviour, IWallSlidable
{
    [SerializeField] private string SlidableWallTag = "SlidableWall";
    [SerializeField] private float slidingSpeed= 3f;

    private bool isSliding;
    private bool isCollidingToWall;

    private GroundChecker groundChecker;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundChecker>();
    }

    void Update()
    {
        WallSlideMovement();
    }

    private void CheckCollision()
    {
        if (groundChecker.IsGrounded || !isCollidingToWall) return;

        int direction = (int)Mathf.Sign(rb.velocity.x);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right * direction);
        
        bool tempChecker = false;
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag(SlidableWallTag))
            {
                tempChecker = true;
                break;
            }
        }

        isSliding = tempChecker;
    }

    
    private void WallSlideMovement()
    {
        CheckCollision();
        if (!isSliding) return;

        rb.gravityScale = 0f;
        rb.velocity = new Vector2(0, -slidingSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(SlidableWallTag))
        {
            isCollidingToWall = true;
        }
        else
        {
            isCollidingToWall = false;
        }
    }
    public bool IsWallSliding()
    {
        return isSliding;
    }

    public void WallSlidingEndWithMovement()
    {
        throw new System.NotImplementedException();
    }

    public void WallSlidingEndWithJump()
    {
        throw new System.NotImplementedException();
    }
}
