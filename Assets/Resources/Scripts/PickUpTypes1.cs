using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTypes1 : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("Ellen").GetComponent<TimeDilution>().timeResource++;
            Destroy(gameObject);


        }
    }

}
