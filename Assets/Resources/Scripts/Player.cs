using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject gun;

    RaycastHit hit;
    LayerMask enemy;
    Ray ray;

    private float shootRange = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Shoot();
    }
    void Shoot()
    {
        Debug.Log("You shot!");
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * shootRange, Color.yellow);




        if (Physics.Raycast(gun.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, enemy))
        {
            //  Debug.DrawRay(gun.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
    }

    private void Update()
    {

        if (Input.mousePosition.y > 0)
        {

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);

            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }


    }

    public void Move(InputAction.CallbackContext context)
    {



        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * moveSpeed;
        }

    }

}



