using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneMaquina : MonoBehaviour {

    private GameObject fogo;

    // Use this for initialization
    void Start() {

        fogo = GameObject.Find("FireComplex");
        fogo.SetActive(false);
        StartCoroutine(waitSeconds(10));
        StartCoroutine(callScene(13));
    }

    private IEnumerator waitSeconds(float tempo) {

        yield return new WaitForSeconds(tempo);
        fogo.SetActive(true);
    }

    private IEnumerator callScene(float tempo) {

        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene("faseCorredor");
    }    
}
