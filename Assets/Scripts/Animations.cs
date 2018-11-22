using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

	public Animator anim;
	

	void Start () {
		
		anim.GetComponent<Animator>();
	}

	void Update () {
		if(Player.gameOver)
		{
			anim.Play("bg");
		
			
			
		}
		else
		{
			
			anim.Play("New State");
		}
		
	}
}
