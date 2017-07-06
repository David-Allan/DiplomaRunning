using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneMaquina : MonoBehaviour {

    private GameObject fogo;
    private GameObject healthbar;

    // Use this for initialization
    void Start() {

        fogo = GameObject.Find("FireComplex");
        healthbar = GameObject.Find("Healthbar");      
        fogo.SetActive(false);
        healthbar.SetActive(false);
        StartCoroutine(waitSeconds(10));
    }

    private IEnumerator waitSeconds(float tempo) {

        yield return new WaitForSeconds(tempo);
        fogo.SetActive(true);
        healthbar.SetActive(true);
    }
}
