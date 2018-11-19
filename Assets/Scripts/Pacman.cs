using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pacman : MonoBehaviour {

public GameObject ShieldPP;
	public NavMeshAgent agent;
	public GameObject[] PP;
	public TextMesh textMesh;
	public int score;
	public bool death;

	float randomDRange;
	float timer;
	float x;
	float z;
	float[] range;
	bool attack;
	public string pacNameVAlue;
	public static string pacName;

	public bool giveShield;
	float delay;
	
    public float wanderTimer;
	public Vector3[] randPos;
	int wichRandPos;
    private Transform target;
    
	public Material[] mat;
	int matInt;
	
	void Start () {
	//	wichRandPos = Random.Range(0,4);
//		target.position = randPos[wichRandPos];
		matInt  =Random.Range(0,6);
		GetComponent<Renderer>().material = mat[matInt];
		attack =false;
		timer = wanderTimer;
		ShieldPP.SetActive(false);
		delay = 5;
		giveShield =false;
		score = Random.Range(5,100);
		death =false;
		textMesh.GetComponent<TextMesh>();
		textMesh.text = score.ToString();
	}
	
	void Update () {
		if(!attack)
		{
			randomMove();
		}
		else
		{
			//	agent.SetDestination(target.position);
			//if(Vector3.Distance(transform.position,target.position)<=0.5)
		//	{
			//	attack =false;
			//}
		}
		if(giveShield)
			{
				delay-=Time.deltaTime;
				if(delay<0)
					{
						giveShield =false;
						ShieldPP.SetActive(false);
						delay = 5;
					}
			}

		if(death)
		{
		
			Instantiate(PP[matInt],transform.position,Quaternion.identity);
			pacName = pacNameVAlue;
			Destroy(gameObject);
			death =false;
			
		}
		}
		
		void randomMove()
		{
			 timer += Time.deltaTime;
			
        if (timer >= wanderTimer) {
            wichRandPos = Random.Range(0,4);
            agent.SetDestination(randPos[wichRandPos]);
			timer = 0;
        }
		float distanse = Vector3.Distance(transform.position,randPos[wichRandPos]);
			if(distanse<2)
			{
				timer = wanderTimer;
			}
		}

	private void OnTriggerEnter(Collider other){

		if(other.gameObject.tag=="Pac" || other.gameObject.tag == "Player" || other.gameObject.tag == "Shield" )
		{
			attack = true;
		}
		else
		{
			attack =false;
		}
		
	}
		private void OnTriggerStay(Collider other) {
		
		
		if(other.gameObject.tag=="Player")
		{
			if(other.gameObject.GetComponent<Player>()!=null)
			{
					if(other.gameObject.GetComponent<Player>().score<score && !other.gameObject.GetComponent<Player>().giveShield)
			{
				agent.SetDestination(other.gameObject.transform.position);
			//	target = other.gameObject.transform;
			}
			else
			{
				
				Vector3 dirToPlayer = transform.position-other.gameObject.transform.position;
				Vector3 newPos = transform.position+dirToPlayer;
				agent.SetDestination(newPos);
				//target.position = newPos;
			}
			if(!other.gameObject.GetComponent<Player>().giveShield && giveShield)
			{
				agent.SetDestination(other.gameObject.transform.position);
				//target = other.gameObject.transform;
			}
			}
			
			
				}
		
		
		if(other.gameObject.tag=="Pac")
		{
			if(other.gameObject.GetComponent<Pacman>()!=null)
			{
					if(other.gameObject.GetComponent<Pacman>().score<score && !other.gameObject.GetComponent<Pacman>().giveShield)
			{
				agent.SetDestination(other.gameObject.transform.position);
				//target = other.gameObject.transform;
			}
			else
			{
				Vector3 dirToPlayer = transform.position-other.gameObject.transform.position;
				Vector3 newPos = transform.position+dirToPlayer;
				agent.SetDestination(newPos);
				//target.position = newPos;
			}
			if(!other.gameObject.GetComponent<Pacman>().giveShield && giveShield)
			{
				agent.SetDestination(other.gameObject.transform.position);
				//target = other.gameObject.transform;
			}
			}
				
		}
		if(other.gameObject.tag== "Shield")
		{
			
			agent.SetDestination(other.gameObject.transform.position);
			//target = other.gameObject.transform;
		}
		
		
	}
	private void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Pac" || other.gameObject.tag =="Player" || other.gameObject.tag =="Shield")
		{
			 attack =false;
		}
		
	}
	private void OnCollisionEnter(Collision others) {
		
		if(others.gameObject.tag =="Shield")
		{
				giveShield =true;
				ShieldPP.SetActive(true);
		}
		
		if(others.gameObject.tag == "Pac")
		{
			if(others.gameObject.GetComponent<Pacman>()!=null){
				if(others.gameObject.GetComponent<Pacman>().score<score && !others.gameObject.GetComponent<Pacman>().giveShield)
			{
				others.gameObject.GetComponent<Pacman>().death =true;
				attack =false;
				score+=10;
				textMesh.text = score.ToString();
				
			}
			if(giveShield && !others.gameObject.GetComponent<Pacman>().giveShield)
			{
				others.gameObject.GetComponent<Pacman>().death =true;
				attack =false;
				score+=10;
				textMesh.text = score.ToString();
			}
			}
			
			
		}
		if(others.gameObject.tag == "Player")
		{
			if(others.gameObject.GetComponent<Player>()!=null)
			{
					if(others.gameObject.GetComponent<Player>().score<score && !others.gameObject.GetComponent<Player>().giveShield)
			{
				others.gameObject.GetComponent<Player>().death =true;
				attack =false;
				score+=10;
				textMesh.text = score.ToString();
				
			}
			if(giveShield && !others.gameObject.GetComponent<Player>().giveShield)
			{
				others.gameObject.GetComponent<Player>().death =true;
				attack =false;
				score+=10;
				textMesh.text = score.ToString();
			}
			}
		
		}
		if(others.gameObject.tag =="Dots")
		{
			score++;
			textMesh.text = score.ToString();
		}
	}
}
