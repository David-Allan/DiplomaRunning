using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class CollectScript : MonoBehaviour {

    public AudioClip collect;

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            collider.GetComponent<MovementScript>().coins++;
            GameObject.Find("CoinsGUI").GetComponent<Text>().text = collider.GetComponent<MovementScript>().coins.ToString();
            GameObject.Find("GameController").GetComponent<GameController>().totalCoins++;
            GameObject.Find("GameController").GetComponent<GameController>().currentCoins = GameObject.Find("Player").GetComponent<MovementScript>().coins;
            AudioSource.PlayClipAtPoint(collect, transform.position, 0.15F);
            gameObject.SetActive(false);
        }
    }
}