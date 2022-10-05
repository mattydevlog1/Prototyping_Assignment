using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    public GameObject gun;


    public static float damage = 1;

    Ray ray;

    private float shootRange = 30f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Shoot();
        }

    }

    void Shoot()
    {

        {
            RaycastHit hit;
            if (Physics.Raycast(gun.transform.position, transform.TransformDirection(Vector3.forward), out hit, shootRange))
            {
                // Vector3 forward = transform.TransformDirection(Vector3.forward) * 30;
                // Debug.DrawRay(transform.position, forward, Color.green);


                if (hit.collider.gameObject.CompareTag("Enemy"))
                {

                    Target target = hit.collider.gameObject.GetComponent<Target>();
                    target.Hit(damage);

                    // Debug.Log("Target is hit");

                    //  Target target = gameObject.GetComponent<Target>();
                    //  target.Hit(damage);
                }
            }
        }

    }
}
