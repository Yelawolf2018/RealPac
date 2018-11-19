using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonFunctions : MonoBehaviour {


public void Restart()
{
	Player.gameOver =false;
 	SceneManager.LoadScene("demo");
}
public void startGame()
{
	Time.timeScale =1;
}
}
