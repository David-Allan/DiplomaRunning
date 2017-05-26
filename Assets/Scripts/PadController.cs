using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour {

    public bool isActive = false;
    public bool isVisible = false;
    public Vector2 velocity;
    private Rigidbody2D rb;

    private void FixedUpdate() {

    }

    void OnTriggerStay2D(Collider2D objeto) {

        rb = objeto.GetComponent<Rigidbody2D>();

        if (rb.CompareTag("Player")) {

            rb.AddForce(velocity * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
