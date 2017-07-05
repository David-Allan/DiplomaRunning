using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtinguisherController : MonoBehaviour {

    public ParticleSystem ps;
    private Vector2 position;
    private Vector3 scale;
    private GameObject setaInvisivel;
    Quaternion rotacao;


    public void Start() {

        setaInvisivel = GameObject.Find("Seta03");
        setaInvisivel.SetActive(false);
        ps = GetComponent<ParticleSystem>();
        scale = new Vector3(0.8F, 1.3F, 0.3F);
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        GameObject.Find("Prateleira09").SetActive(false);
        GameObject.Find("Trampolim05").SetActive(false);
        GameObject.Find("PlataformaEscada").SetActive(false);
        GameObject.Find("Seta01").SetActive(false);
        GameObject.Find("Seta02").SetActive(false);
        setaInvisivel.SetActive(true);
        Destroy(GameObject.Find("Escada").GetComponent<Rigidbody2D>());
        Destroy(GameObject.Find("Escada").GetComponent<Collider2D>());

        gameObject.transform.SetParent(GameObject.Find("L_Hand").transform);
        rotacao = GameObject.Find("Player").transform.rotation;
        position = GameObject.Find("L_Hand").transform.position;
        gameObject.transform.SetPositionAndRotation(position, rotacao);

        transform.localScale = scale;
        collider.GetComponent<MovementScript>().hasObject = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    void OnParticleTrigger() {

        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);

        for (int i = 0; i < numEnter; i++) {

            ControllerMaquina controller = GameObject.Find("MaquinaSalgadinhos").GetComponent<ControllerMaquina>();

            if (controller.vida < 100F) {
                controller.vida += 0.03F;
                controller.AumentarBarraVida();
            }
            else break;
        }
    }
}
