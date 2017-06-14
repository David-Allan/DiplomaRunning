using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

     void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")){

            if (collider.GetComponent<MovementScript>().deathCounter < 2) {

                collider.GetComponent<MovementScript>().deathCounter++;
                Vector3 startPosition = new Vector3 (-26.78F, -4.12F, 0);
                Quaternion rotation = collider.transform.rotation;
                collider.GetComponent<Transform>().SetPositionAndRotation(startPosition, rotation); 
            }
            else SceneManager.LoadScene("gameOver");
        }
    }
}
