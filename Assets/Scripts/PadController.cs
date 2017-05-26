using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour {

    public bool isActive;
    public bool isVisible;
    public Vector2 velocity;
    private Rigidbody2D rb;
    private int maxSpeed = 4;

    private void Start() {

        isActive = true;
        isVisible = true;
    }

    void OnTriggerStay2D(Collider2D objeto) {

        rb = objeto.GetComponent<Rigidbody2D>();

        if (rb.CompareTag("Player") && rb.velocity.x < maxSpeed)
            rb.AddForce(velocity * Time.deltaTime, ForceMode2D.Impulse);
        
    }
}
