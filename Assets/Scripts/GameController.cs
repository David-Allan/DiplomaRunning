using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int totalCoins;
    public int currentCoins;
    public int finishTime;

    KeyCode leftKey;
    KeyCode rightkey;
    KeyCode downKey;
    KeyCode jumpkey;
    KeyCode itemKey;

    void Start() {

        totalCoins = 0;
        currentCoins = 0;
        DontDestroyOnLoad(gameObject);
    }

    public void gameButtons(int option) {

        switch (option) {

            case 1:
                leftKey = KeyCode.LeftArrow;
                rightkey = KeyCode.RightArrow;
                downKey = KeyCode.DownArrow;
                jumpkey = KeyCode.UpArrow;
                itemKey = KeyCode.LeftShift;

            break;
            case 2:
                leftKey = KeyCode.LeftArrow;
                rightkey = KeyCode.RightArrow;
                downKey = KeyCode.DownArrow;
                jumpkey = KeyCode.Space;
                itemKey = KeyCode.LeftShift;
            break;
            case 3:
                leftKey = KeyCode.A;
                rightkey = KeyCode.D;
                downKey = KeyCode.S;
                jumpkey = KeyCode.W;
                itemKey = KeyCode.LeftShift;
            break;
            case 4:
                leftKey = KeyCode.A;
                rightkey = KeyCode.D;
                downKey = KeyCode.S;
                jumpkey = KeyCode.Space;
                itemKey = KeyCode.LeftShift;
            break;
        }
    }
}

