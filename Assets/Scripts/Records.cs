using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Records : MonoBehaviour {
    public GUISkin MyCustomSkin;

    private void Start()
    {
        GameObject.Find("Value (1)").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
        GameObject.Find("Value (2)").GetComponent<Text>().text = PlayerPrefs.GetInt("second").ToString();
        GameObject.Find("Value (3)").GetComponent<Text>().text = PlayerPrefs.GetInt("third").ToString();
        GameObject.Find("Value (4)").GetComponent<Text>().text = PlayerPrefs.GetInt("fourth").ToString();
        GameObject.Find("Value (5)").GetComponent<Text>().text = PlayerPrefs.GetInt("fifth").ToString();
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 1.4f, Screen.width / 4f, Screen.height / 10f), "", MyCustomSkin.GetStyle("play")))
        {
            GameManager.gameOver = false;
            GameManager.gameStart = false;
            GameManager.score = 0;
            SceneManager.LoadScene(0);
        }
    }
}
