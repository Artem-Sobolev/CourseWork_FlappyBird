using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool gameStart = false;
    public static int score = 0;

    void Start()
    {
        score = 0;
        gameOver = false;
        gameStart = false;
    }
    
    void Update()
    {
        if (!gameStart)
        {

            if (Input.GetMouseButtonDown(0))
            {
                gameStart = true;
            }
        }
        if (gameStart)
            if (Input.GetKeyUp(KeyCode.Escape))
                Application.Quit();
    }
}
