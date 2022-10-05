using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{
    [SerializeField]
    public GameObject Shotgun;


    public static float damage = 1;

    Ray ray;

    private float shootRange = 15f;

    public Animator player;

    private void Start()
    {
        player = GameObject.Find("Ellen").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 15;
        Debug.DrawRay(transform.position, forward, Color.green);


        if (Input.GetMouseButtonDown(0))
        {
            player.SetTrigger("IsShooting");
            Shoot();
        }

    }

    void Shoot()
    {

        {
            RaycastHit hit;
            if (Physics.Raycast(Shotgun.transform.position, transform.TransformDirection(Vector3.forward), out hit, shootRange))
            {



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
