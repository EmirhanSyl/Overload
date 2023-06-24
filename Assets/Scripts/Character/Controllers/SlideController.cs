using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour, ISlidable
{
    [SerializeField] private float slideCooldown = 1f;
    [SerializeField] private float slideDuration = 1f;

    [SerializeField] private float slideSpeed = 1f;

    [Header("SLIDE COLLIDER SETTINGS")]
    [SerializeField] private float slideColliderWidth;
    [SerializeField] private float slideColliderHeigh;
    [SerializeField] private Vector2 slideCollOffset;

    private float colliderWidth;
    private float colliderHeigh;

    private bool isSliding;
    private bool canSlide = true;

    private GroundChecker groundChecker;
    private BoxCollider2D coll;
    private SpriteRenderer sRenderer;
    private Rigidbody2D rb;


    void Awake()
    {
        groundChecker = GetComponentInChildren<GroundChecker>();
        rb = GetComponent<Rigidbody2D>();
        sRenderer = GetComponentInChildren<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        colliderHeigh = coll.size.y;
        colliderWidth = coll.size.x;
    }

    void Update()
    {
        if (isSliding)
        {
            int direction = (sRenderer.flipX) ? -1: 1;
            rb.velocity = new Vector2(slideSpeed * direction, rb.velocity.y);
        }
    }

    public void HandleSlide()
    {
        if (!isSliding && canSlide && groundChecker.IsGrounded)
        {
            StartCoroutine(SlideRoutine());
        }
    }

    private IEnumerator SlideRoutine()
    {
        coll.size = new Vector2(slideColliderWidth, slideColliderHeigh);
        coll.offset = slideCollOffset;
        isSliding = true;
        canSlide = false;
        yield return new WaitForSeconds(slideDuration);
        isSliding = false;
        yield return new WaitForSeconds(0.15f);
        coll.size = new Vector2(colliderWidth, colliderHeigh);
        coll.offset = Vector2.zero;
        yield return new WaitForSeconds(slideCooldown);
        canSlide = true;

    }

    public bool IsSliding()
    {
        return isSliding;
    }
}
