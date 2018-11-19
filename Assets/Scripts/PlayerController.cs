using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	bool up,down,right,left;
	public float moveSpeed = 5f;
//    int t;
	private void Start() {
      //  t = 0;
		up = false;
		down =false;
		right =false;
		left =false;
	}
	void Update () {
        Swipe();
    }
    
        
    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    bool isHold = false;

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
                       down = true;
					   up = false;
		
						right =false;
						left =false;
						
                    }
                }
            }
        }
		wichWay();
       
    }
	void wichWay()
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
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag =="Wall")
        {
            
                if(up)
                {
                    transform.position = new Vector3(transform.position.x,transform.position.y ,transform.position.z-0.2f);
                    up =false;
                }
                else if(down)
                {
                    transform.position = new Vector3(transform.position.x,transform.position.y ,transform.position.z+0.2f);
                    down =false;
                }
                else if(left)
                {
                    transform.position = new Vector3(transform.position.x+0.2f,transform.position.y ,transform.position.z);
                    left =false;
                }
                else if(right)
                {
                    transform.position = new Vector3(transform.position.x-0.2f,transform.position.y ,transform.position.z);
                    right =false;
                }
                 
        }
    }
   
}