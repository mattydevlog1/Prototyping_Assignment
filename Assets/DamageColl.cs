using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColl : MonoBehaviour
{


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            GameObject.Find("Ellen").GetComponent<Player>().playerCurrentHp--;
        }
    }
}
