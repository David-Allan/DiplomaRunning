using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustsceneCameraCorredor : MonoBehaviour {

    public Vector3 posicaoFinal;
    public float velocidade;
    

    private void Start() {

        velocidade = 12;
        enabled = false;
        StartCoroutine(waitSeconds(3));

    }

    void Update() {

        transform.position = Vector3.MoveTowards(transform.position, posicaoFinal, Time.deltaTime * velocidade);
    }

    private IEnumerator waitSeconds(float time) {

        yield return new WaitForSeconds(time);
        enabled = true;
    }
}
