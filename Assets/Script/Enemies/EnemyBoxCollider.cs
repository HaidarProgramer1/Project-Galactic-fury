using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoxCollider : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D mainCollider;
    private BoxCollider2D triggerCollider;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();

        if (colliders.Length > 1)
        {
            mainCollider = colliders[1];
            triggerCollider = colliders[0];

            mainCollider.isTrigger = false;
            triggerCollider.isTrigger = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGroundLayer(collision.gameObject.layer))
        {
            triggerCollider.enabled = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (IsGroundLayer(collision.gameObject.layer))
        {
            triggerCollider.enabled = false;
        }
    }

    private bool IsGroundLayer(int layer)
    {
        return groundLayer == (groundLayer | (1 << layer));
    }
}
