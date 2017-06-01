using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask WhatIsGround;
    public Animator animacao;


    public float groundCheckRadius;
    private bool isGrounded;

    private Vector2 velocity;
    private const float maxSpeed = 6;
    public float jumpforce;
    

    void Start(){

        rb = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
    }

    private void FixedUpdate() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        if (isGrounded){

            velocity.x = 8;
        }
    }

    void Update () {

        if (!isGrounded)
        {
            velocity.x = 2;
        }

        //-----------------------------------------------------------------------//


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {

            animacao.SetBool("Jump", !isGrounded);
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }


        //-----------------------------------------------------------------------//


        if (Input.GetKey(KeyCode.D))
        {

            if (rb.velocity.x < maxSpeed)
            {

                rb.AddForce(velocity * Time.deltaTime, ForceMode2D.Impulse);
            }
        }


        //-----------------------------------------------------------------------//


        if (Input.GetKey(KeyCode.A)) {

            if (rb.velocity.x < maxSpeed)
            {

                rb.AddForce(-velocity * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        if (rb.velocity.x < 0){

            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0){

            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //define as animacoes que devem ser utilizadas no personagem
        animacao.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }
}