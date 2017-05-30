using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(AudioSource))]

public class CollectScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            gameObject.GetComponent<AudioSource>().Play();
            collider.GetComponent<MovementScript>().coins++;
            gameObject.SetActive(false);
        }
    }
}