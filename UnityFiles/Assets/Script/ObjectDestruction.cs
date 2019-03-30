using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestruction : MonoBehaviour
{
    int amountOfKnigeDodged = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Shredder"))
        {
            Destroy(gameObject);
            amountOfKnigeDodged++;
            Debug.Log("Game Over" + amountOfKnigeDodged);
        }

        if (other.gameObject.tag.Equals("CuttingBoard"))
        {
            Destroy(gameObject);
        }
    }
}

