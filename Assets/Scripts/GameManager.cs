using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {


	public GameObject[] pacman;
	public Transform[] spawnPos;
	public GameObject restartBut;
	public GameObject startBut;
	public RawImage bg;
	
	public Text highScore;
	public RawImage highScoreTitle;
	public Text currentScore;
	int whichPos;

	void Start () {
		Time.timeScale = 0;
		restartBut.GetComponent<Button>();
		startBut.GetComponent<Button>();
		restartBut.SetActive(false);
		bg.GetComponent<Image>();
		highScoreTitle.GetComponent<RawImage>();
		currentScore.GetComponent<Text>();
		currentScore.enabled =false;
		bg.enabled =true;
	}
	void Update () {
			if(Player.gameOver)
			{
				
				gameOver();
			
			}
			if(ButtonFunctions.start)
				{
					gameStartB();
				}
		reSpawnPacs();
	}
	void reSpawnPacs()
	{
		if(Pacman.pacName == "Bob")
		{
			whichPos =Random.Range(0,63);
			Instantiate(pacman[0],spawnPos[whichPos].position,Quaternion.identity);
			
			Pacman.pacName = "";
		}
		
	}
	void gameOver()
	{
		restartBut.SetActive(true);
				currentScore.enabled = true;
				bg.enabled = true;
				highScoreTitle.enabled =true;
				highScore.enabled =true;
	}
	void gameStartB()
	{
		bg.enabled = false;
					startBut.SetActive(false);
					highScore.enabled =false;
					highScoreTitle.enabled =false;
					Time.timeScale =1;
					ButtonFunctions.start =false;
	}
}
