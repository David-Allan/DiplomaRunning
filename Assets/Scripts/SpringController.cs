﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour {

    public Vector2 velocidade;
    public AudioClip som;

    void OnTriggerEnter2D(Collider2D objeto) {

        if (objeto.CompareTag("Player")) {

            AudioSource.PlayClipAtPoint(som, transform.position);
            objeto.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            objeto.GetComponent<Rigidbody2D>().AddForce(velocidade, ForceMode2D.Impulse);
        }
    }
}
