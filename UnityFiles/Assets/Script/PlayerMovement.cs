using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    private float xDirection;
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        xDirection = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector3(xDirection, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Shredder"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}
