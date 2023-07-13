using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSpawner : MonoBehaviour
{
    [SerializeField] Vector2 xSpawnRange = new Vector2(-7.5f, 7.5f);
    [SerializeField] float spawnDelay = 1;
    [SerializeField] int numberOfShipTypes;

    float spawnTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Health.Instance.gameOver)
        {
            if (spawnTimer >= spawnDelay)
            {
                Vector2 spawnPos = new Vector2(Random.Range(xSpawnRange.x, xSpawnRange.y), transform.position.y);

                SpaceshipPool.Instance.SpawnSpaceship((ShipTypes)Random.Range(0, numberOfShipTypes), spawnPos);

                spawnTimer = 0;
            }

            spawnTimer += Time.deltaTime;
        }
    }
}
