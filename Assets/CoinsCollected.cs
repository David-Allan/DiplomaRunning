using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollected : MonoBehaviour {

    public int coins;
    Text texto;

    void Start() {

        texto = GetComponent<Text>();
        coins = GameObject.Find("GameController").GetComponent<GameController>().currentCoins;

        if (coins == 0)
            texto.text = 0.ToString();
        else texto.text = coins.ToString();

        GameObject.Find("CoinsGUI").GetComponent<Text>().text = coins.ToString();
    }
}
