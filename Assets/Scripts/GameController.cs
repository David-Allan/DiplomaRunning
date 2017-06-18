using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int totalCoins;
    public int currentCoins;

    void Start() {

        DontDestroyOnLoad(GameObject.Find("GameController"));
        totalCoins = 0;
        currentCoins = 0;
    }
}

