using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustsceneCameraCorredor : MonoBehaviour {

    public Vector3 posicaoFinal;
    public float velocidade;
    public AudioClip backgroundMusic;

    private void Start() {

        velocidade = 12;
        enabled = false;
        StartCoroutine(WaitSeconds(3));
        StartCoroutine(CallScene(13));
    }

    void Update() {

        transform.position = Vector3.MoveTowards(transform.position, posicaoFinal, Time.deltaTime * velocidade);

    }

    private IEnumerator WaitSeconds(float time) {

        yield return new WaitForSeconds(time);
        enabled = true;
    }

    private IEnumerator CallScene(float tempo) {

        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene("faseCorredor");
    }

    IEnumerator ChangeFOV(float tempoEspera, float duracao) {

        float currentTime = 0.0F;
        float startSize = Camera.main.orthographicSize;
        float finalTime = duracao + tempoEspera;
        
        yield return new WaitForSeconds(tempoEspera);

        while (currentTime < finalTime) {

            currentTime += Time.deltaTime;
            Camera.main.orthographicSize = Mathf.Lerp(startSize, startSize/2, duracao);        }
    }
}