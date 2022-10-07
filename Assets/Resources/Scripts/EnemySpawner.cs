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
    float delayAndSpawnRate = 1;
    float timeUntilSpawnRateIncrease = 5;

    void Start()
    {
        StartCoroutine(SpawnObject(delayAndSpawnRate));
    }

    IEnumerator SpawnObject(float firstDelay)
    {
        float spawnRateCountdown = timeUntilSpawnRateIncrease;
        float spawnCountdown = firstDelay;
        while (true)
        {
            yield return null;
            spawnRateCountdown -= Time.deltaTime;
            spawnCountdown -= Time.deltaTime;

            // Should a new object be spawned?
            if (spawnCountdown < 0)
            {
                spawnCountdown += delayAndSpawnRate;
                Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPos[Random.Range(0, spawnPos.Length)].transform.position, Quaternion.identity);
            }

            // Should the spawn rate increase?
            if (spawnRateCountdown < 0 && delayAndSpawnRate > 1)
            {
                spawnRateCountdown += timeUntilSpawnRateIncrease;
                delayAndSpawnRate -= 0.1f;
            }
        }
    }
}
