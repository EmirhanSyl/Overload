using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController : MonoBehaviour, IDashable
{
    [SerializeField] private float dashForce = 10f;
    [SerializeField] private float dashDuration = 0.2f;

    private bool isDashing = false;

    private Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing)
        {
            rb.velocity = new Vector2(dashForce * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        }
    }

    public void HandleDash()
    {
        if (!isDashing)
        {
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator DashRoutine()
    {
        isDashing = true;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    public bool IsDashing()
    {
        return isDashing;
    }
}
