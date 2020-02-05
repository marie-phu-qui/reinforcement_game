using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [Header("REFERENCES")]
    public GameObject UIObject;         //  Reference to the GameObject that contains the UIScript

    [Header("RDEBUG")]
    public BoxCollider collisionCollider;


    private void Start()
    {
        // Find the UI gameObject by using its tag
        // Give UIObject a value
        UIObject = GameObject.FindWithTag("UIObject");

        // Give the collisionCollider variable a value
        collisionCollider = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {

        // If an object with the 'Player' tag hits the trigger
        if (other.CompareTag("Player"))
        { 
            // Increment the collision counter in UIScript
            UIObject.gameObject.GetComponent<UIScript>().IncrementCollisionCount();

            // Disable the collider so that it doesn't count multiple collisions
            collisionCollider.enabled = false;
        }

    }

}
