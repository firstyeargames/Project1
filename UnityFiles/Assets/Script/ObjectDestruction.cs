using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    int amountOfKnigeDodged = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Shredder"))
        {
            Destroy(gameObject);
            amountOfKnigeDodged++;
            Debug.Log("Game Over" + amountOfKnigeDodged);
        }


        if (other.gameObject.name == "CuttingBoard")
        {
            Destroy(gameObject);
            amountOfKnigeDodged++;
            Debug.Log("Game Over" + amountOfKnigeDodged);
        }
    }
}

