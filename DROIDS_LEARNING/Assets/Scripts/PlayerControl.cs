using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [Header("MOVEMENT SETTINGS")]
    public float thrust = 300f;
    public float dampening = 5.0f;


    [Header("DEBUG")]
    public Text verticalInputText;
    public Text horizontalInputText;
    public bool manualInput = false;

    // PRIVATE VARIABLES
    Rigidbody rbody;
    float vertical;
    float horizontal;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        vertical = 1f;
    }

    private void FixedUpdate()
    {
        if (manualInput == true) // Get horizontal input axis values from key input
        {
            horizontal = Input.GetAxis("Horizontal");
        }

        else // Generate horizontal input axis values at random
        {
            horizontal = Random.Range(-1f, 1f);
        }


        // Adds force, based on axis input and multiplies it by 'thrust'
        rbody.AddForce(new Vector3(horizontal, 0, vertical) * thrust);

        // Debug UI
        verticalInputText.text = "VERTICAL INPUT: " + vertical;
        horizontalInputText.text = "HORIZONTAL INPUT: " + horizontal;
    }



}