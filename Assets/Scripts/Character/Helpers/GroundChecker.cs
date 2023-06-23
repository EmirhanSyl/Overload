using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private static readonly string GROUND_TAG = "Ground";

    private bool isGrounded;

    public bool IsGrounded => isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GROUND_TAG))
        {
            isGrounded = false;
        }
    }
}
