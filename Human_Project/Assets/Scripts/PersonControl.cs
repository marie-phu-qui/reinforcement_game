using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonControl : MonoBehaviour
{
    // FixedUpdate is called once per physics frame
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
}
