using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    public float smoothSpd = 0.125f;
    public Vector3 offset;
    // private void FixedUpdate() {
    // 	if(player !=null)
    // 	{

    // 	Vector3 desiredPos = player.transform.position+offset;
    // 	Vector3 smoothPos = Vector3.Lerp(transform.position,desiredPos,smoothSpd);
    // 	transform.position = smoothPos;
    // 	transform.LookAt(player.transform);
    // 	}
    // }
    private void FixedUpdate()
    {
        if (player != null)
        {
            followPlayer();

        }
    }
    void followPlayer()
    {
        Vector3 desiredPos = player.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpd);
        transform.position = smoothPos;
        transform.LookAt(player.transform);
    }
}
