using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform player;

    [Header("Spawner Things")]
    public float spawnRate;
    public GameObject MeleeEnemy;

    private int waveAmount = 0; //how many enemies spawn within the current wave


    [Range(0.0f, 1.0f)]
    public float spawnChance;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerTruck").transform;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {

        waveAmount = Random.Range(14, 34);

        while (waveAmount > 0)
        {
             yield return new WaitForSeconds(spawnRate);
            player = GameObject.FindGameObjectWithTag("PlayerTruck").transform;
             if (Random.Range(0.0f, 1.0f) <= spawnChance)
            {
                Instantiate(MeleeEnemy, new Vector3(player.position.x + randomSpawnPosX(), player.position.y + randomSpawnPosY(), 0f), Quaternion.identity);
            }
            waveAmount --;
        }

        yield return new WaitForSeconds(Random.Range(7, 15));

        StartCoroutine(SpawnEnemies());

    }

    private float randomSpawnPosX()
    {
        float randomNum = Random.Range(-14f, -30f);

        if (Random.Range(0,2) == 1)
        {
            randomNum *= -1f;
        }
        
        return randomNum;
    }

    private float randomSpawnPosY()
    {
        float randomNum = Random.Range(10f, 30f);

        if (Random.Range(0,2) == 1)
        {
            randomNum *= -1f;
        }

        return randomNum;
    }
}
