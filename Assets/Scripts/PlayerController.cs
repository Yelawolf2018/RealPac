using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	bool up,down,right,left;
    public float smoothHurricaine = 0.05f;
	public float moveSpeed = 5f;
//    int t;
    public GameObject[] wich;
	private void Start() {
        collide =false;
      //  t = 0;
		up =  true;
		down =false;
		right =false;
		left =false;
	}
	void Update () {
        //Swipe();
    }
    private void FixedUpdate() {
        Swipe();
    }
    
        
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    bool isHold = false;
    bool collide;
    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            isHold = true;
        
        }
        if (Input.GetMouseButtonUp(0))
        {
            
        //    if(collide)
        //    {
        //         if(up)
        //         {
        //             transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y ,transform.position.z-0.2f),smoothHurricaine);
        //             up =false;
        //         }
        //         else if(down)
        //         {
        //             transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y ,transform.position.z+0.2f),smoothHurricaine);
        //             down =false;
        //         }
        //         else if(left)
        //         {
        //             transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x+0.2f,transform.position.y ,transform.position.z),smoothHurricaine);
        //             left =false;
        //         }
        //         else if(right)
        //         {
        //             transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x-0.2f,transform.position.y ,transform.position.z),smoothHurricaine);
        //             right =false;
        //         }
        //         collide = false;
        //    }
            isHold = false;
           
        }

        if (isHold)
        {
            float dragDistance = 20.0f;

            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            //currentSwipe.Normalize();

            float tmpX = currentSwipe.x;
            float tmpY = currentSwipe.y;

            if (tmpX < 0)
            {
                tmpX = tmpX * -1;
            }

            if (tmpY < 0)
            {
                tmpY = tmpY * -1;
            }


            if (tmpX > tmpY)
            {
                if (tmpX > dragDistance)
                {
                    //swipe left
                    if (currentSwipe.x < 0)
                    {
                        
                        
                              left = true;
                        
                      
                        up = false;
						down =false;
						right =false;
						
                    }
                    else
                    {
                        //swipe right
                     
                       
                              right = true;
                        
					   	up = false;
						down =false;
						left =false;
						
                    }
                }
            }
            else
            {
                if (tmpY > dragDistance)
                {
                    //swipe upwards
                    if (currentSwipe.y > 0)
                    {
                        
                              up = true;
                        
                        
						down =false;
						right =false;
						left =false;
						
                    }
                    //swipe down
                    if (currentSwipe.y < 0)
                    {
                     
                              down =true;
                        
					   up = false;
		
						right =false;
						left =false;
						
                    }
                }
            }
        }
		wichWay();
       
    }
	public void wichWay()
	{
          transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical")* moveSpeed);
           transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal")* moveSpeed); 
        if(!collide)
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
	}
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag =="Wall")
        {
            // collide =true;

            
                if(up)
                {
                    
                   up =false;
                  
                }
                else if(down)
                {
                    
                }
                else if(left)
                {
                  
                     left =false;
                    
                }
                else if(right)
                {
                      
                    right =false;
                  
                }
               // collide =false;
            
                
        }
    }
   
}