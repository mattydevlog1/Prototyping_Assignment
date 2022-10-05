using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    [SerializeField] private EnemyState enemyState;

    private Animator anim;

    private NavMeshAgent navAgent;

    [SerializeField]
    private Transform destination;
    public float damage;

    [SerializeField] private Transform blood;
    public AudioSource zombieMoan;
    public AudioSource zombieAttack;
    public AudioSource zombieDie;




    private void Awake()
    {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        zombieMoan = gameObject.GetComponent<AudioSource>();
        zombieAttack = gameObject.GetComponent<AudioSource>();
        zombieDie = gameObject.GetComponent<AudioSource>();


        navAgent.SetDestination(destination.position);
        Target target = gameObject.GetComponent<Target>();
    }

    private void Start()
    {

    }

    void Update()
    {
        switch (enemyState)
        {

            case EnemyState.Idle:
                break;
            case EnemyState.Chase:

                break;
            case EnemyState.Attack:

                break;

        }
        AnimateZombie();
    }
    void AnimateZombie()
    {
        if (navAgent.velocity.magnitude > 0)
        {
            zombieMoan.Play();
            anim.SetBool("Walk", true);
        }
        else
            anim.SetBool("Walk", false);
        zombieMoan.Pause();
    }

    private void OnTriggerEnter(Collider other)
    {
        Target target = other.gameObject.GetComponent<Target>();




        //   target.Hit(damage);
        //     Instantiate(blood, transform.position, Quaternion.identity);



    }


}