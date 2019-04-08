using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public bool ButtonMovement;
    private bool isFlat;
    public Rigidbody rb;
    private float xDirection;
    private float moveSpeed = 5f;
    float maxSpeed = 10f;
    bool leftButton, rightButton;

    // Start is called before the first frame update
    void Start()
    {
        isFlat = true;
        ButtonMovement = true;
        rb = GetComponent<Rigidbody>();
        rightButton = false;
        leftButton = false;
    }

    private void Update()
    {
        Statements();
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Shredder"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }

    public void UsingAccelerometerMovement()
    {
        Vector3 tilt = new Vector3(Input.acceleration.x, 0f, 0f);
        float accSpeed = 150f;
        //Direction pointing downward
        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }

        rb.AddForce(tilt * accSpeed);
    }

    public void leftButtonFunction()
    {
        leftButton = true;
        rightButton = false;
    }

    public void rightButtonFunction()
    {
        rightButton = true;
        leftButton = false;
    }

    private void Statements()
    {
        if (ButtonMovement == false)
        {
            UsingAccelerometerMovement();
            Debug.Log("accccellerorting");
            rightButton = false;
            leftButton = false;
        }

        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            if (leftButton == true)
            {
                rb.GetComponent<Rigidbody>().velocity = (-Vector3.right * moveSpeed);
                rightButton = true;
            }
            else if (rightButton == true)
            {
                rb.GetComponent<Rigidbody>().velocity = (Vector3.right * moveSpeed);
                leftButton = false;
            }
        }
    }

}
