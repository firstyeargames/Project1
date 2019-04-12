using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    public GameObject particle;
    public GameObject slicedWatermelon;
    Vector3 position = new Vector3(2.25f, -3.9f, 0.9f);

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Shredder") || other.gameObject.tag.Equals("CuttingBoard"))
        {
            Instantiate(particle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.tag.Equals("Player"))
        {
            Instantiate(slicedWatermelon, position, Quaternion.identity);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

