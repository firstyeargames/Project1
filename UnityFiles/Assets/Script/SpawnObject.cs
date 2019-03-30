using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject obj;
    GameObject spawnHolder;
    Vector3 objPosition;
    Rigidbody objRigidbody;
    float maxSpawnRange, minSpawnRange, randomSpawns;
    public List<GameObject> spawnList = new List<GameObject>();


    private void Start()
    {
        maxSpawnRange = 5.8f;
        minSpawnRange = -1.6f;
        // Spawn object every 2 seconds, 1 second apart
        InvokeRepeating("spawnObj", 2f, 1f);
        objRigidbody = obj.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        // Random range for spawning but within camera screen
        randomSpawns = Random.Range(minSpawnRange, maxSpawnRange);
        objPosition = new Vector3(randomSpawns, 10f, 1f);

    }

    void spawnObj()
    {   
        spawnHolder = Instantiate(obj, objPosition, Quaternion.identity);
        spawnHolder.transform.eulerAngles = new Vector3(90f, 0f, 90f);
        objRigidbody.velocity = new Vector3(0, Random.Range(0, 1) * Time.deltaTime, 0);
        spawnList.Add(spawnHolder);
        objRigidbody.useGravity = true;
    }
}
