using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

	public Animator anim;
	public static bool showOther =false;
	float timer;
	void Start () {
		timer = 0;
		anim.GetComponent<Animator>();
	}

	void Update () {
		if(Player.gameOver)
		{
			anim.Play("bg");
			timer +=Time.deltaTime;
			if(timer>0.5f)
			{
				showOther = !showOther;
			}
			
		}
		else
		{
			timer = 0;
			anim.Play("New State");
		}
		
	}
}
