using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class computerGuyEaster : MonoBehaviour {

    public Text texto1;
    public Text texto2;
    public Text texto3;

    private void OnTriggerStay2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            texto1.text = "??";
            texto2.text = "??";
            texto3.text = "??";
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {

        if (collider.CompareTag("Player")) {

            texto1.text = "";
            texto2.text = "";
            texto3.text = "";
        }
    }
}
