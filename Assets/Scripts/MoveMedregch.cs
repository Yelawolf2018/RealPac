using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMedregch : MonoBehaviour {

	public string wichTri;
	public string WichTrigger;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay(Collider other) {
		if(other.gameObject.tag =="Wall")
		{
			WichTrigger = wichTri;
		}
	}
}
