using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pacman : MonoBehaviour {


public GameObject ShieldPP;

	public GameObject[] PP;
	public TextMesh textMesh;
	public int score;
	public bool death;
	public string pacNameVAlue;
	public static string pacName;

	public bool giveShield;
	float delay;
	
    public Material[] mat;
	int matInt;
	bool up,down,right,left;
    public float smoothHurricaine = 0.05f;
	public float moveSpeed = 5f;
	int where;
	void Start () {
		where = Random.Range(0,4);
					if(where == 0)
					{
						right =true;
					}
					else if(where == 1)
						 {
							 up = true;
						 }
					else if(where ==3)
						 {
							down = true;
						 }
					else
					{
						left = true;
					}
		
		matInt  =Random.Range(0,6);
		GetComponent<Renderer>().material = mat[matInt];
		
	
		ShieldPP.SetActive(false);
		delay = 5;
		giveShield =false;
		score = Random.Range(5,100);
		death =false;
		textMesh.GetComponent<TextMesh>();
		textMesh.text = score.ToString();
	}
	
	void Update () {
		randomMove();
		// if(!attack)
		// {
		
		// 	randomMove();
		// }
		
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
			if(up)
			{
				transform.Translate(0,0,moveSpeed*Time.deltaTime);
			}
			else if(down)
			{
				transform.Translate(0,0,-moveSpeed*Time.deltaTime);
			}
			else if(left)
			{
				transform.Translate(-moveSpeed*Time.deltaTime,0,0);
			}
			else if(right)
			{
				transform.Translate(moveSpeed*Time.deltaTime,0,0);
			}
		}
	

	private void OnCollisionEnter(Collision others) {
		if(others.gameObject.tag == "Wall")
		{
			if(up)
                {
					
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y ,transform.position.z-0.25f),smoothHurricaine);
                    up =false;
					where = Random.Range(0,4);
					if(where == 0)
					{
						down =true;
					}
					else if(where == 1)
						 {
							 left = true;
						 }
					else if(where ==3)
						 {
							 right = true;
						 }
					else
					{
						right =true;
					}
                }
                else if(down)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y ,transform.position.z+0.25f),smoothHurricaine);
                    down =false;
					where = Random.Range(0,4);
					if(where == 0)
					{
						up =true;
					}
					else if(where == 1)
						 {
							 left = true;
						 }
					else if(where ==3)
						 {
							 right = true;
						 }
					else
					{
						right =true;
					}
                }
                else if(left)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x+0.25f,transform.position.y ,transform.position.z),smoothHurricaine);
                    left =false;
					where = Random.Range(0,4);
					if(where == 0)
					{
						right =true;
					}
					else if(where == 1)
						 {
							 up = true;
						 }
					else if(where ==3)
						 {
							down = true;
						 }
					else
					{
						down =true;
					}
                }
                else if(right)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x-0.25f,transform.position.y ,transform.position.z),smoothHurricaine);
                    right =false;
					where = Random.Range(0,4);
					if(where == 0)
					{
						left=true;
					}
					else if(where == 1)
						 {
							 up = true;
						 }
					else if(where ==3)
						 {
							down = true;
						 }
					else
					{
						down =true;
					}
                }
		}
			
		
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
			
				score+=10;
				textMesh.text = score.ToString();
				
			}
			if(giveShield && !others.gameObject.GetComponent<Pacman>().giveShield)
			{
				others.gameObject.GetComponent<Pacman>().death =true;
				
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
			
				score+=10;
				textMesh.text = score.ToString();
				
			}
			if(giveShield && !others.gameObject.GetComponent<Player>().giveShield)
			{
				others.gameObject.GetComponent<Player>().death =true;
			
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
