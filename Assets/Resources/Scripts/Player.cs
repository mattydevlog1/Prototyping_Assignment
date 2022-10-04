using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject gun;

    float playerMaxHp = 5;
    float playerCurrentHp;
    float enemyDmg = 1;

    public static float damage = 1;


    public GameObject enemy;

    Ray ray;

    private float shootRange = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCurrentHp = playerMaxHp;
    }


    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gun.transform.position, transform.TransformDirection(Vector3.forward), out hit, shootRange))
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {

                Target target = hit.collider.gameObject.GetComponent<Target>();
                target.Hit();

                // Debug.Log("Target is hit");

                //  Target target = gameObject.GetComponent<Target>();
                //  target.Hit(damage);
            }
        }
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


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

        if (playerCurrentHp <= 0)
        {
            Debug.Log("Youdied");
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


    void OnTriggerEnter(Collider other)
    {
        playerCurrentHp = playerCurrentHp - enemyDmg;
    }

}










