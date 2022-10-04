using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnTimer;
    float spawnLimit;



    [SerializeField]
    Rigidbody enemy;

    [SerializeField]
    GameObject spawn;

    void Start()
    {
        spawnLimit = 1;
        spawnTimer = 60;
    }


    void Update()
    {
        if (spawnLimit > 0)
        {
            spawnLimit--;
        }
        if (spawnTimer >= 0)

            Spawn();

    }
    void Spawn()
    {

        if (spawnLimit >= 0)
        {
            spawnLimit--;
            InvokeRepeating("SpawnEnemy", 0f, 3f);
        }
    }
    void SpawnEnemy()
    {
        Rigidbody instance = Instantiate(enemy);
        enemy.transform.position = spawn.transform.position;
    }
}