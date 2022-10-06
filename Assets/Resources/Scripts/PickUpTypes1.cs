using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTypes1 : MonoBehaviour
{
    public GameObject timeEffect;
    public GameObject ellen;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("Ellen").GetComponent<TimeDilution>().timeResource++;
            Instantiate(timeEffect, ellen.transform);
            Destroy(gameObject);


        }
    }

}
