using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float EnemyCurrentHp = 5;


    float gunDamage1 = 1;

    public static bool isHit;


    private void Start()
    {


        isHit = false;

    }

    private void Update()
    {
        if (EnemyCurrentHp < 0)
        {

            EnemyDeath();

        }

        if (isHit)
        {
            TakeDamage();

        }

        void EnemyDeath()
        {
            if ((EnemyCurrentHp < 0 && isHit))
            {
                Destroy(gameObject);
            }
        }

    }




    public void TakeDamage()
    {
        EnemyCurrentHp = EnemyCurrentHp - gunDamage1;
        Debug.Log(EnemyCurrentHp);
    }
}


