using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    Animator animacao;

    private void Start() {

        animacao = GameObject.Find("Player").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            if (collider.GetComponent<MovementScript>().deathCounter < 2) {

                collider.GetComponent<MovementScript>().enabled = false;
                StartCoroutine(outsideBounds(collider));
            }
            else SceneManager.LoadScene("gameOver");
        }
    }

    IEnumerator outsideBounds(Collider2D collider) {

        animacao.SetBool("Down", true);
        animacao.Play("SlidePlayer");
        yield return new WaitForSecondsRealtime(1);
        returnStart(collider);
    }

    private void returnStart(Collider2D collider) {
        
        animacao.SetBool("Down", false);
        animacao.Play("Idle");
        collider.GetComponent<MovementScript>().enabled = true;
        collider.GetComponent<MovementScript>().deathCounter++;
        Vector3 startPosition = new Vector3(-26.78F, -4.12F, 0);
        Quaternion rotation = collider.transform.rotation;
        collider.GetComponent<Transform>().SetPositionAndRotation(startPosition, rotation);
    }
}
