﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public bool ButtonMovement;
    private bool isFlat;
    Rigidbody rb;
    private float xDirection;
    private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        isFlat = true;
        ButtonMovement = true;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(ButtonMovement == true) {
            UsingButtonMovement();
        }

        if(ButtonMovement == false)
        {
            UsingAccelerometerMovement();
            Debug.Log("accccellerorting");
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Shredder"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }

    void UsingButtonMovement()
    {
        xDirection = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector3(xDirection, 0f, 0f);
    }

    void UsingAccelerometerMovement()
    {
        Vector3 tilt = new Vector3(Input.acceleration.x, 0f, 0f);
        float accSpeed = 100f;
        //Direction pointing downward
        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }

        rb.AddForce(tilt * accSpeed);
    }
}
