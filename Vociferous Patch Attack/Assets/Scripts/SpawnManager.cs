using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Transform player;

    [Header("Spawner Things")]
    public float spawnRate;
    public GameObject MeleeEnemy;


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

        while (true)
        {
             yield return new WaitForSeconds(spawnRate);
            player = GameObject.FindGameObjectWithTag("PlayerTruck").transform;
             if (Random.Range(0.0f, 1.0f) <= spawnChance)
            {
                Instantiate(MeleeEnemy, new Vector3(player.position.x + randomSpawnPosX(), player.position.y + randomSpawnPosY(), 0f), Quaternion.identity);
            }
        }

    }

    private float randomSpawnPosX()
    {
        float randomNum = Random.Range(-14f, -19f);

        if (Random.Range(0,2) == 1)
        {
            randomNum *= -1f;
        }
        
        return randomNum;
    }

    private float randomSpawnPosY()
    {
        float randomNum = Random.Range(10f, 15f);

        if (Random.Range(0,2) == 1)
        {
            randomNum *= -1f;
        }

        return randomNum;
    }
}
