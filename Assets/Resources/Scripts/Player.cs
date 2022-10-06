using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;





public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed;


    float playerMaxHp = 5;
    public float playerCurrentHp;
    float enemyDmg = 1;

    public Animator player;

    public GameObject enemy;

    public HealthBar healthBar;





    private void Start()
    {
        player = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerCurrentHp = playerMaxHp;
        healthBar.SetMaxHealth((int)playerMaxHp);


    }




    void Update()
    {
        Debug.Log(playerCurrentHp);





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
            Destroy(gameObject);
        }



        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            player.SetBool("IsWalking", true);

        }
        else
        {
            player.SetBool("IsWalking", false);
        }

    }





    void OnTriggerEnter(Collider other)
    {
        playerCurrentHp = playerCurrentHp - enemyDmg;
        healthBar.SetHealth((int)playerCurrentHp);
    }

}










