using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    public GameObject gun;

    public GameObject firepoint;

    public GameObject projectile;

    public AudioClip shootSound;


    public static float damage = 1;

    Ray ray;

    private float shootRange = 30f;

    


    public Animator player;
    // Update is called once per frame


    private void Start()
    {
        player = GameObject.Find("Ellen").GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {

            
            player.SetTrigger("IsShooting");
            Shoot();
            Instantiate(projectile, firepoint.transform.position, firepoint.transform.rotation);
            AudioSource.PlayClipAtPoint(shootSound, firepoint.transform.position);
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
