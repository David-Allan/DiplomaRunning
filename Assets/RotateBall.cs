using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour {

    private Rigidbody2D rb;
    private Rigidbody2D colliderRb;

    private Vector2 pushVelocity;

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {
            colliderRb = collider.GetComponent<Rigidbody2D>();
            pushVelocity = new Vector2(colliderRb.velocity.x/15, colliderRb.velocity.y/15);

            rb.AddForce(pushVelocity, ForceMode2D.Impulse);
            transform.Rotate(0, 0, -pushVelocity.x*400);
        }
    }
}
