using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUITimer : MonoBehaviour {

    float timer;
    Text textoTimer;

	// Use this for initialization
	void Start () {

        textoTimer = GetComponent<Text>();
        timer = 0.2F;
    }
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        int tempo = (int)timer;
        textoTimer.text = tempo.ToString();        
	}
}
