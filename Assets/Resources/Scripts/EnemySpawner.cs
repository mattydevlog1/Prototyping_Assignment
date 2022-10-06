using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnTimer;
    float spawnLimit;

    public int spawnlocation;

    public GameObject[] spawnPos = new GameObject[9];



    
    public GameObject[] enemy = new GameObject[10];

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
        Instantiate(enemy[Random.Range(0, spawnPos.Length)], spawnPos[Random.Range(0, spawnPos.Length)].transform.position, Quaternion.identity);

    }
}
