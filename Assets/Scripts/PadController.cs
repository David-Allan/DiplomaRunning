using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour {

    public bool isActive;
    public bool isVisible;
    public Vector2 velocity;
    private Rigidbody2D rb;
    private int maxSpeed;

    private void Start() {

        isActive = true;
        isVisible = true;
        maxSpeed = 5;
    }

    private void OnTriggerEnter2D(Collider2D objeto) {

        
    }

    void OnTriggerStay2D(Collider2D objeto) {

        rb = objeto.GetComponent<Rigidbody2D>();

        if (rb.CompareTag("Player") && rb.velocity.x < maxSpeed) {

            //rb.AddForce(velocity * Time.fixedDeltaTime, ForceMode2D.Impulse);

            rb.AddForce(new Vector2(maxSpeed - rb.velocity.x, 0));
        }
    }
}
