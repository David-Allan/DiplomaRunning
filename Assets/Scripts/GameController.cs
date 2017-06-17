using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    int totalCoins;

    void Start() {

        DontDestroyOnLoad(GameObject.Find("GameController"));
        totalCoins = 0;
    }
}

