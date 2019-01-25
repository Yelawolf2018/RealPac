using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Pacman : MonoBehaviour
{

    public GameObject splatter;
    public GameObject ShieldPP;
    public GameObject[] PP;
    public TextMesh textMesh;
    public int score;
    public bool death;
    public string pacNameVAlue;
    public static string pacName;
    Transform target;
    public bool giveShield;
    float delay;
    public Material[] mat;
    int matInt;
    public GameObject[] decals;

    bool up, down, right, left;
    public float smoothHurricaine = 0.05f;
    public float moveSpeed = 5f;
    // int where;
    // public GameObject[] which;
    //public int[] nonActive;
    int ranges;
    public float wanderTimer = 2f;
    //	float timer;
    void Start()
    {
        matInt = Random.Range(0, 6);
        GetComponent<Renderer>().material = mat[matInt];
        ShieldPP.SetActive(false);
        delay = 5;
        giveShield = false;
        score = Random.Range(5, 10);
        death = false;
        textMesh.GetComponent<TextMesh>();
        textMesh.text = score.ToString();
    }

    void Update()
    {
        realRandomMove();

        if (giveShield)
        {
            giveShieldD();
        }

        if (death)
        {
            deathActions();
        }
    }
    void giveShieldD()
    {
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            giveShield = false;
            ShieldPP.SetActive(false);
            delay = 5;
        }
    }
    void deathActions()
    {
        Instantiate(PP[matInt], transform.position, Quaternion.identity);
        Instantiate(decals[matInt], new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.identity);
        pacName = pacNameVAlue;
        Destroy(gameObject);
        death = false;
    }
    void realRandomMove()
    {
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    // void findOpenRoad()
    // {
    // 	int t =0;
    // 	for (int i = 0; i < which.Length; i++)
    // 	{
    // 		if (which[i].name !="active")
    // 		{
    // 			nonActive[t] = i;
    // 			t++;
    // 		}
    // 		ranges = t;
    // 	}
    // }
    // public void RandomNavSphere () {
    // 	findOpenRoad();
    // //   where = Random.Range(0,8);
    // // 			if(where == 0 )
    // // 			{
    // // 				down =true;
    // // 			}
    // // 			else if(where == 1 )
    // // 				 {
    // // 					 down = true;
    // // 				 }
    // // 			else if(where ==3 )
    // // 				 {
    // // 					 left = true;
    // // 				 }
    // // 			else if(where == 4)
    // // 			{
    // // 				left =true;
    // // 			}
    // // 			else if(where == 5)
    // // 			{
    // // 				up =true;
    // // 			}
    // // 			else if(where == 6)
    // // 			{
    // // 				up =true;
    // // 			}
    // // 			else if(where == 7)
    // // 			{
    // // 				right =true;
    // // 			}
    // // 			else
    // // 			{
    // // 				right =true;
    // // 			}
    // 	where = Random.Range(0,ranges);
    // 		if(nonActive[where] == 0)
    // 		{
    // 			up =true;
    // 		}
    // 		else if(nonActive[where] == 1)
    // 		{
    // 			right = true;
    // 		}
    // 		else if(nonActive[where]==2)
    // 		{
    // 			left = true;
    // 		}
    // 		else
    // 		{
    // 			down =true;
    // 		}
    // 	 }
    // void randomMove()
    // {
    // 	timer += Time.deltaTime;

    // if (timer >= wanderTimer) {
    // 		RandomNavSphere();
    //     timer = 0;
    // }

    // 	if(up)
    // 	{
    // 		transform.Translate(0,0,moveSpeed*Time.deltaTime);
    // 	}
    // 	else if(down)
    // 	{
    // 		transform.Translate(0,0,-moveSpeed*Time.deltaTime);
    // 	}
    // 	else if(left)
    // 	{
    // 		transform.Translate(-moveSpeed*Time.deltaTime,0,0);
    // 	}
    // 	else if(right)
    // 	{
    // 		transform.Translate(moveSpeed*Time.deltaTime,0,0);
    // 	}
    // }


    private void OnCollisionEnter(Collision others)
    {


        if (others.gameObject.tag == "Shield")
        {
            giveShield = true;
            ShieldPP.SetActive(true);
        }

        if (others.gameObject.tag == "Pac")
        {
            if (others.gameObject.GetComponent<Pacman>() != null)
            {
                if (others.gameObject.GetComponent<Pacman>().score < score && !others.gameObject.GetComponent<Pacman>().giveShield)
                {
                    others.gameObject.GetComponent<Pacman>().death = true;

                    score += 10;
                    textMesh.text = score.ToString();

                }
                if (giveShield && !others.gameObject.GetComponent<Pacman>().giveShield)
                {
                    others.gameObject.GetComponent<Pacman>().death = true;

                    score += 10;
                    textMesh.text = score.ToString();
                }
            }


        }
        if (others.gameObject.tag == "Player")
        {
            if (others.gameObject.GetComponent<Player>() != null)
            {
                if (others.gameObject.GetComponent<Player>().score < score && !others.gameObject.GetComponent<Player>().giveShield)
                {
                    others.gameObject.GetComponent<Player>().death = true;

                    score += 10;
                    textMesh.text = score.ToString();

                }
                if (giveShield && !others.gameObject.GetComponent<Player>().giveShield)
                {
                    others.gameObject.GetComponent<Player>().death = true;

                    score += 10;
                    textMesh.text = score.ToString();
                }
            }

        }
        if (others.gameObject.tag == "Dots")
        {
            score++;
            textMesh.text = score.ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "p")
        {
            int length = other.gameObject.GetComponent<Node>().nearlyP.Length;
            int rand = Random.Range(0, length);
            target = other.gameObject.GetComponent<Node>().nearlyP[rand];
        }
    }
    private void OnDrawGizmos()
    {

        if (target != null)
        {
            Gizmos.DrawLine(transform.position, target.position);
        }

    }
}
