using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CollectScript : MonoBehaviour {

    public AudioClip collect;

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            collider.GetComponent<MovementScript>().coins++;
            //GameObject.Find("GameController").GetComponent<GameController>().to
            AudioSource.PlayClipAtPoint(collect, transform.position);
            gameObject.SetActive(false);
        }
    }
}