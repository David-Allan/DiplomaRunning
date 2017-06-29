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
        texto.text = (3 - player.GetComponent<MovementScript>().deathCounter).ToString(); 
	}
	
	// Update is called once per frame
	void Update () {

        texto.text = (3 - player.GetComponent<MovementScript>().deathCounter).ToString();
    }
}
