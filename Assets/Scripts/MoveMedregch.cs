using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMedregch : MonoBehaviour
{



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //	active1 = true;
            gameObject.name = "active";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            gameObject.name = "nonActive";
            //active1=false;
        }
    }
}
