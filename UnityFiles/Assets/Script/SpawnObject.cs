using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject obj;
    Vector3 objPosition;
    Rigidbody objRigidbody;
    float maxSpawnRange, minSpawnRange, randomSpawns;
    public List<GameObject> spawnList = new List<GameObject>();


    private void Start()
    {
        maxSpawnRange = 3.5f;
        minSpawnRange = -3.5f;
        // Spawn object every 2 seconds, 1 second apart
        InvokeRepeating("spawnObj", 2f, 1f);
        objRigidbody = obj.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        // Random range for spawning but within camera screen
        randomSpawns = Random.Range(minSpawnRange, maxSpawnRange);
        objPosition = new Vector3(randomSpawns, 15, 15);
    }

    void spawnObj()
    {
        GameObject spawnHolder;
        spawnHolder = Instantiate(obj, objPosition, Quaternion.identity);
        objRigidbody.velocity = new Vector3(0, Random.Range(1, 5), 0);
        spawnList.Add(spawnHolder);
    }
}
