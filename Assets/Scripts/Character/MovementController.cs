using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour, IMovable
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float decceleration = 0.2f;
    [SerializeField] private float accelerationPower = 2f;
    [SerializeField] private float friction = 1f;

    private Vector2 moveInput;
    private Rigidbody2D rb;


    void Start()
    {
        moveInput = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float targetSpeed = moveInput.x * moveSpeed;
        float speedDifferance = targetSpeed - rb.velocity.x;

        float accelerationRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float movement = Mathf.Pow(Mathf.Abs(speedDifferance) * accelerationRate, accelerationPower) * Mathf.Sign(speedDifferance);
        ApplyFriction(ref moveInput);

        rb.AddForce(movement * Vector2.right);
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    public void HandleMovement(float horizontalInput)
    {
        moveInput.x = horizontalInput;
    }

    private void ApplyFriction(ref Vector2 velocity)
    {
        if (velocity.x > 0)
        {
            velocity.x -= friction * Time.deltaTime;
            velocity.x = Mathf.Max(velocity.x, 0f);
        }
        else if (velocity.x < 0)
        {
            velocity.x += friction * Time.deltaTime;
            velocity.x = Mathf.Min(velocity.x, 0f);
        }
    }
}
