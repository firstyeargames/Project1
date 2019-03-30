using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 50f;
    bool rightBool, leftBool, stopBool;

    void Start()
    {
        rightBool = false;
        leftBool = false;
        stopBool = false;
        rigidbody = GetComponent<Rigidbody>();
    }

    public void moveRight()
    {
        rightBool = true;
        leftBool = false;
        stopBool = false;
    }

    public void moveLeft()
    {
        leftBool = true;
        rightBool = false;
        stopBool = false;
    }

    public void stopMovement()
    {
        stopBool = true;
        leftBool = false;
        rightBool = false;
        Debug.Log("stop");
    }

    private void FixedUpdate()
    {
        Debug.Log("spped" + speed);

        if(rightBool == true)
        {
            rigidbody.velocity = Vector3.right * speed * Time.deltaTime;

        }
        if (stopBool == true)
        {
            rigidbody.velocity = Vector3.zero;

        }

        if (leftBool == true)
        {
            rigidbody.velocity = Vector3.left * speed * Time.deltaTime;

        }
      

        
      
    }
}
