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

    public GameObject healEffect;

    public GameObject ellen;





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





        Vector3 lookDirection = new Vector3(Input.GetAxisRaw("RightHoriz"), 0, Input.GetAxisRaw("RightVert"));
        transform.rotation = Quaternion.LookRotation(lookDirection);

        if (playerCurrentHp <= 0)
        {
            Debug.Log("Youdied");           
            player.SetBool("IsDead", true);
            rb.isKinematic = true;
            this.enabled = false;
            
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HealthBox")
        {
            playerCurrentHp++;
            healthBar.SetHealth((int)playerCurrentHp);

            Instantiate(healEffect, ellen.transform);
            


}
    }

}










