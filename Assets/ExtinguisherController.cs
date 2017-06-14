using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherController : MonoBehaviour {

    private Vector2 position;
    private Vector3 scale;
    Quaternion rotacao;

    public void Start() {

        rotacao = new Quaternion(0, 28, 0, 0);
        scale = new Vector3(0.7F, 0.7F, 0.7F);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider) {

        gameObject.transform.SetParent(GameObject.Find("L_Hand").transform);
        position = GameObject.Find("L_Hand").transform.position;
        gameObject.transform.SetPositionAndRotation(position, rotacao);

        transform.localScale -= scale;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}