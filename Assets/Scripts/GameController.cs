using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int totalCoins;
    public int currentCoins;
    public int finishTime;

    void Start() {

        totalCoins = 0;
        currentCoins = 0;
        DontDestroyOnLoad(gameObject);
    }
}

