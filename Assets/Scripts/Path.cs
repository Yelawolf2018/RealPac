using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {


	public Transform[] path;
	public float speed = 5;
	public float reachDist =1;
	public int currentPoint = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(path[currentPoint].position,transform.position);
		transform.position = Vector3.MoveTowards(transform.position,path[currentPoint].position,speed*Time.deltaTime);
		if(dist <=reachDist)
		{
			currentPoint++;
		}
		if(currentPoint >= path.Length)
		{
			currentPoint = 0;
		}
	}
	private void OnDrawGizmos() {
		for (int i = 0; i < path.Length; i++)
		{
			if(path[i] !=null)
			{
				
					Gizmos.DrawLine(transform.position,path[i].position);	
				
				
			}
		}
	}
}
