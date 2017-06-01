using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLimpeza : MonoBehaviour {

    private int contato;
    public Sprite spriteZelador;
    public GameObject zelador;

    void Start () {

        contato = 0;
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D collider) {

        if(contato != 1 && collider.CompareTag("Player")) {

            GameObject.Find("Zelador01").GetComponent<SpriteRenderer>().sprite = spriteZelador;
            contato = 1;
        }       
        
	}
}
