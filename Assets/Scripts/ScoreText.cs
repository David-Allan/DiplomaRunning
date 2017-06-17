using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public Transform player;
    private Text texto;
    
	// Use this for initialization
	void Start () {

        texto = GetComponent<Text>();
        texto.text = "Vidas: " + (3 - player.GetComponent<MovementScript>().deathCounter); 
	}
	
	// Update is called once per frame
	void Update () {

        texto.text = "Vidas: " + (3 - player.GetComponent<MovementScript>().deathCounter);
    }
}
