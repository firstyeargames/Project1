using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    float speed;
    float xDirection;
    private bool rightBtn, leftBtn; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightBtn = false;
        leftBtn = false;
    }

    public void moveRight() {
        rightBtn = true;
    }

    public void moveLeft()
    {
        leftBtn = true;
        Debug.Log("click");
    }

    void Update()
    {
        if(rightBtn == true)
        {
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }

        if (leftBtn == true)
        {
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }
    }
}
