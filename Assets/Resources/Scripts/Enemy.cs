using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float EnemyCurrentHp = 5;
    float EnemyDamageTaken;
    float timesHit;
    float gunDamage1 = 1;

    public static bool isHit;


    private void Start()
    {
        EnemyCurrentHp = 5;
        EnemyDamageTaken = 0;
        timesHit = 0;
        isHit = false;

    }

    private void Update()
    {
        if (EnemyCurrentHp < 0)
        {
            //   isHit = true;
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



    public static void Hit()
    {
        isHit = true;
        // Debug.Log("ok");
    }
    public void TakeDamage()
    {
        EnemyCurrentHp = EnemyCurrentHp - gunDamage1;
        Debug.Log(EnemyCurrentHp);
    }
}


