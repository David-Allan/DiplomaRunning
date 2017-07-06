using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public KeyCode leftKey;
    public KeyCode rightkey;
    public KeyCode downKey;
    public KeyCode jumpkey;
    public KeyCode itemKey;

    public int totalCoins;
    public int currentCoins;
    public int finishTime;

    void Awake() {

        totalCoins = 0;
        currentCoins = 0;
        setButtons();
        DontDestroyOnLoad(gameObject);
    }

    public void setButtons() {

        MainMenu menu = GameObject.Find("MenuController").GetComponent<MainMenu>();

        leftKey = menu.leftKey;
        rightkey = menu.rightkey;
        downKey = menu.downKey;
        jumpkey = menu.jumpkey;
        itemKey = menu.itemKey;

        Destroy(GameObject.Find("MenuController"));
    }
}

