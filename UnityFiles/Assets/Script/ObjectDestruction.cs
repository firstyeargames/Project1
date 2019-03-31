using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Shredder"))
        {
            Destroy(gameObject);
        }


        if (other.gameObject.tag.Equals("CuttingBoard"))
        {
            Destroy(gameObject);
        }
    }
}

