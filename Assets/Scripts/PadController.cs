using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour {

    public bool isActive;
    public bool isVisible;
    public Vector2 velocity;
    private Rigidbody2D rb;
    public int maxSpeed;
    public int speed;

    private void Start() {

        isActive = true;
        isVisible = true;
        speed = 5;
        maxSpeed = 5;        
    }

      void OnTriggerStay2D(Collider2D objeto) {

        rb = objeto.GetComponent<Rigidbody2D>();

        if (/*rb.CompareTag("Player") &&*/ rb.velocity.x < maxSpeed) {

            //objeto.GetComponent<Animator>().SetFloat("Speed", 0);
            rb.AddForce(velocity * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
}
