using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMaquina : MonoBehaviour {

    public float vida;
    public ParticleSystem ps;

    // Use this for initialization
    void Start() {

        ps = GetComponent<ParticleSystem>();
        vida = 100;
    }

    // Update is called once per frame
    void FixedUpdate() {

        vida -= 0.015F;
    }

    void OnParticleTrigger() {

        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        if (numEnter > 0) {

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

