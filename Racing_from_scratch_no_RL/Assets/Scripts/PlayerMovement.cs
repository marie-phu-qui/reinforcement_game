using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // INITIAL MOVEMENT ACTION
    //movement speed in units per second
    private float movementSpeed = 10f;
    float y;
    void FixedUpdate()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0f, verticalInput * movementSpeed * Time.deltaTime);
        //update the rotate angle
        y += Time.deltaTime * horizontalInput * 200f;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }

    /*
    // new movement action
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        var dirToGo = Vector3.zero;
        var rotateDir = Vector3.zero;

        if (Input.GetKey("right"))
        {
            rotateDir = transform.up * 1f;
            transform.Rotate(rotateDir, Time.deltaTime * 200f);
        }
        if (Input.GetKey("up"))
        {
            dirToGo = transform.forward * 1f;
            rb.AddForce(dirToGo * 2f, ForceMode.VelocityChange);
        }
        if (Input.GetKey("left"))
        {
            rotateDir = transform.up * -1f;
            transform.Rotate(rotateDir, Time.deltaTime * 200f);
        }
        if (Input.GetKey("down"))
        {
            dirToGo = transform.forward * -1f;
            rb.AddForce(dirToGo * 2f, ForceMode.VelocityChange);
        }
    }
    */

    void PlayerReset()
    {
        //whenever done()
        transform.position = new Vector3(0, 0.5f, -4);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            GameObject.Find("CubeAgent").SendMessage("Finish");
            PlayerReset();
        }
    }
}