using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonFunctions : MonoBehaviour
{

    public static bool start = false;
    public void Restart()
    {
        Player.gameOver = false;
        SceneManager.LoadScene("demo");
    }
    public void startGame()
    {
        start = true;
        Time.timeScale = 1;
    }
}
