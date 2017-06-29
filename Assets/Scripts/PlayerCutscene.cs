using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCutscene : MonoBehaviour {

    private Animator animacao;
    private Rigidbody2D myRigidbody2D;
    public Vector3 posicaoFinal;

    private void Start() {

        animacao = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {

        if (transform.position.x < posicaoFinal.x) {
            transform.position = Vector3.MoveTowards(transform.position, posicaoFinal, Time.deltaTime * 2);
            animacao.SetFloat("Speed", 2);
        }
        else animacao.SetFloat("Speed", 0);
    }
}
