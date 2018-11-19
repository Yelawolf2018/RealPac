using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {


	public GameObject[] pacman;
	public Vector3[] spawnPos;
	public GameObject restartBut;
	public RawImage bg;
	
	public Text highScore;
	public RawImage highScoreTitle;
	public Text currentScore;
	int whichPos;

	void Start () {
		Time.timeScale = 0;
		restartBut.GetComponent<Button>();
		restartBut.SetActive(false);
		bg.GetComponent<Image>();
		highScoreTitle.GetComponent<RawImage>();
		currentScore.GetComponent<Text>();
		currentScore.enabled =false;
		//bg.enabled =false;
	
	}
	void Update () {
			if(Player.gameOver)
			{
				restartBut.SetActive(true);
				currentScore.enabled = true;
				bg.enabled = true;
				highScoreTitle.enabled =true;
				highScore.enabled =true;
			}
			if(Input.GetMouseButtonDown(0))
				{
					bg.enabled =false;
					highScore.enabled =false;
					highScoreTitle.enabled =false;
					Time.timeScale =1;
				
				}
		reSpawnPacs();
	}
	void reSpawnPacs()
	{
		if(Pacman.pacName == "Bob")
		{
			whichPos =Random.Range(0,9);
			Instantiate(pacman[0],spawnPos[whichPos],Quaternion.identity);
			
			Pacman.pacName = "";
		}
		else if(Pacman.pacName =="Clyde")
		{
			whichPos =Random.Range(0,9);
			Instantiate(pacman[1],spawnPos[whichPos],Quaternion.identity);
		
			Pacman.pacName = "";
		}
		else if(Pacman.pacName =="Daniel")
		{
			whichPos =Random.Range(0,9);
			Instantiate(pacman[2],spawnPos[whichPos],Quaternion.identity);
			
			Pacman.pacName = "";
		}
		else if(Pacman.pacName =="Tom")
		{
			whichPos =Random.Range(0,9);
			Instantiate(pacman[3],spawnPos[whichPos],Quaternion.identity);
			
			Pacman.pacName = "";
		}
		else if(Pacman.pacName =="Jack")
		{
			whichPos =Random.Range(0,0);
			Instantiate(pacman[4],spawnPos[whichPos],Quaternion.identity);
			
			Pacman.pacName = "";
		}
	}
	

}
