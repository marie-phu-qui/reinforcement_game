using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement speed in units per second
    private float movementSpeed = 10f;
    float y;
    void Update()
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

        //output to log the position change
        Debug.Log(transform.position);
        Debug.Log(transform.rotation);
    }
    public void PlayerReset()
    {
        //whenever done()
        transform.position = new Vector3(0, 0.5f, -4);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("goal"))
        {
            PlayerReset();
        }
    }
}