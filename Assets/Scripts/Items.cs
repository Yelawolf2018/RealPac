using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {
		float delay;
	bool die;
	MeshCollider coll;
	MeshRenderer mesh;
	public Vector3[] randPos;
	int w;
	
	void Start () {
		mesh = GetComponent<MeshRenderer>();
		coll = GetComponent<MeshCollider>();
		die =false;
	}
	private void Update() {
		if(die)
		{
			delay = Time.timeSinceLevelLoad+15f;
			
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
