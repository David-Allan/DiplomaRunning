using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {
                       
            gameObject.SetActive(false);
            collider.GetComponent<MovementScript>().coins ++;
        }
    }
}
