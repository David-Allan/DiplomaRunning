using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerMaquina : MonoBehaviour {

    public float vida;
    private GameObject explosao;
    private GameObject fogo;
    private GameObject healthBar;

    // Use this for initialization
    void Start() {

        explosao = GameObject.Find("Explosion");
        fogo = GameObject.Find("FireComplex");
        healthBar = GameObject.Find("Vida");
        explosao.SetActive(false);
        vida = 100;
    }


    void FixedUpdate() {

        vida -= 0.015F;
        ReduzirBarraVida();
        if (vida <= 0) StartCoroutine(endGame());
        else if (vida >= 100) SceneManager.LoadScene("youWin");
    }

    private IEnumerator endGame() {

        explosao.SetActive(true);
        fogo.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("gameOver");
    }

    private void ReduzirBarraVida() {

        healthBar.GetComponent<Image>().fillAmount -= 0.00015F;
    }

    public void AumentarBarraVida() {

        healthBar.GetComponent<Image>().fillAmount += 0.0003F;
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            if (GameObject.Find("Player").GetComponent<MovementScript>().deathCounter < 2) {

                GameObject.Find("Player").GetComponent<MovementScript>().deathCounter++;
                Vector3 startPosition = new Vector3(-26.78F, -4.12F, 0);
                Quaternion rotation = GameObject.Find("Player").GetComponent<Transform>().rotation;
                GameObject.Find("Player").GetComponent<Transform>().SetPositionAndRotation(startPosition, rotation);
            }
            else SceneManager.LoadScene("gameOver");
        }
    }
}



//133 - (tempo) + 3(moedas)

//100 > +  todas moedas = SS
//100 > S
//90 > A
//80 > B
//70 > C
//60 > D
//50 > F


// 133 - 63 
//


//63s para completar com todas as moeda (10) = 100 = S

