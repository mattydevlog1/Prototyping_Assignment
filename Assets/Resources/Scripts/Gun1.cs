using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour
{
    [SerializeField]
    public Transform Shotgun;


    public static float damage = 1;

    Ray ray;

    private float shootRange = 15f;

    public Animator player;

    public GameObject ShotgunPf;

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
            Instantiate(ShotgunPf, Shotgun.position, Shotgun.rotation);
            //   Destroy(ShotgunPf, 0.5f);
            //   Shoot();
        }

    }

}
