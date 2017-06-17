using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtinguisherController : MonoBehaviour {

    public ParticleSystem ps;
    private Vector2 position;
    private Vector3 scale;
    Quaternion rotacao;


    public void Start() {

        ps = GetComponent<ParticleSystem>();
        scale = new Vector3(0.7F, 0.7F, 0.7F);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider) {

        gameObject.transform.SetParent(GameObject.Find("L_Hand").transform);
        rotacao = collider.transform.rotation;
        position = GameObject.Find("L_Hand").transform.position;
        gameObject.transform.SetPositionAndRotation(position, rotacao);

        transform.localScale -= scale;
        collider.GetComponent<MovementScript>().hasObject = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void OnParticleTrigger() {

        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        for (int i = 0; i < numEnter; i++) {

            if (GameObject.Find("MaquinaSalgadinhos").GetComponent<ControllerMaquina>().vida < 100F)
                GameObject.Find("MaquinaSalgadinhos").GetComponent<ControllerMaquina>().vida += 0.03F;
            else break;
        }

        if (GameObject.Find("MaquinaSalgadinhos").GetComponent<ControllerMaquina>().vida >= 100F){
            GameObject.Find("MaquinaSalgadinhos").GetComponent<ParticleSystem>().Pause();
            SceneManager.LoadScene("youWin");
        }
    }
}
