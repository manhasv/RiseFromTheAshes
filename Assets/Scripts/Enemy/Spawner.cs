using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnTime = 5;
    public float spawnRadius = 50;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        if (!LevelManager.isGameOver)
        {
            // Random x, z position around the radius of the spawner

            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            spawnPosition.x += Random.Range(-spawnRadius, +spawnRadius);
            spawnPosition.z += Random.Range(-spawnRadius, +spawnRadius);
            GameObject spawnedEnemy = Instantiate(prefab, spawnPosition, transform.rotation) as GameObject;

            spawnedEnemy.transform.parent = gameObject.transform;
        }
    }
}
