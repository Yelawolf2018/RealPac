using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots : MonoBehaviour {

	float delay;
	bool die;
	Collider coll;
	MeshRenderer mesh;
	
	void Start () {
		mesh = GetComponent<MeshRenderer>();
		coll = GetComponent<Collider>();
		die =false;
	}
	private void Update() {
if(die)
{
	delay = Time.timeSinceLevelLoad+10f;
	die =false;
}
{
	regen();
}
		

	}
	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Pac")
		{
			
			die =true;
			mesh.enabled =false;
			coll.enabled =false;
			
		}
	}
	void regen()
	{

		if(Time.timeSinceLevelLoad>delay)
		{
			mesh.enabled =true;
			coll.enabled =true;
		}
	}
	
}
