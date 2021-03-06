using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public KeyCode leftKey;
    public KeyCode rightkey;
    public KeyCode downKey;
    public KeyCode jumpkey;
    public KeyCode itemKey;
    public GameObject panel;

    private void Awake() {

        panel = GameObject.Find("CanvasControles");
        panel.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void selectLevel(string newGameLevel) {

        if (newGameLevel == "selecionarFase") {
            Destroy(GameObject.Find("GameController"));
            SceneManager.LoadScene(newGameLevel);
        }        
        else
            SceneManager.LoadScene(newGameLevel);
    }

    public void endGame() {
        Application.Quit();
    }

    public void callPanel() {

        panel.SetActive(true);
    }

    public void setButtons(int option) {

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
