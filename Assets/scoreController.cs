using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {

    public Text scoreText;
    public Text coinsText;
    public int timer;
    public int coins;
    public int finalScore;

    void Start() {

        coins = GameObject.Find("GameController").GetComponent<GameController>().currentCoins;
        timer = GameObject.Find("GameController").GetComponent<GameController>().finishTime;
        Destroy(GameObject.Find("GameController"));

        coinsText.text = coins.ToString();
        finalScore = (133 - timer) + (4 * coins);

        if (coins == 10) {

            if (finalScore >= 100)
                scoreText.text = "SS";
            else if (finalScore >= 90 && finalScore < 100)
                scoreText.text = "A+";
            else if (finalScore >= 80)
                scoreText.text = "B+";
            else if (finalScore >= 70)
                scoreText.text = "C+";
            else if (finalScore >= 60)
                scoreText.text = "D+";
            else if (finalScore >= 50)
                scoreText.text = "E+";
            else
                scoreText.text = "F+";
        }
        else {

            if (finalScore >= 90)
                scoreText.text = "A";
            else if (finalScore >= 80)
                scoreText.text = "B";
            else if (finalScore >= 70)
                scoreText.text = "C";
            else if (finalScore >= 60)
                scoreText.text = "D";
            else if (finalScore >= 50)
                scoreText.text = "E";
            else
                scoreText.text = "F";
        }
    }
}
