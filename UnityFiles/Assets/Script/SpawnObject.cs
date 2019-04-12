using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject player;
    public GameObject obj;
    GameObject spawnHolder;
    Vector3 objPosition;
    Rigidbody objRigidbody;
    float maxSpawnRange, minSpawnRange, randomSpawns;
    public int knifesSpawned = 0;
    ObjectDestruction objectDestruction;
    public UIManager uIManager;

    private void Start()
    {
        maxSpawnRange = 5.6f;
        minSpawnRange = -1.4f;
        // Spawn object every 2 seconds, 1 second apart
        if(uIManager.panelVisible == false)
        {
            spawnKnifes();
        }

        objRigidbody = obj.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Random range for spawning but within camera screen
        randomSpawns = Random.Range(minSpawnRange, maxSpawnRange);
        objPosition = new Vector3(randomSpawns, 10f, 1f);

        if (player == null)
        {
            CancelSpawns();
        }
    }

    void spawnObj()
    {
        spawnHolder = Instantiate(obj, objPosition, Quaternion.identity);
        spawnHolder.transform.eulerAngles = new Vector3(90f, 0f, 90f);
        objRigidbody.GetComponent<Rigidbody>().drag = Random.Range(5, 10);
        objRigidbody.useGravity = true;
        knifesSpawned++;
    }

    public void CancelSpawns()
    {
        CancelInvoke();
    }

    public void spawnKnifes()
    {
        InvokeRepeating("spawnObj", 2f, 1f);
    }
}
