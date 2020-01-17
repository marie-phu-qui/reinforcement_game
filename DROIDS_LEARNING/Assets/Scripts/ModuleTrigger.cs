using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleTrigger : MonoBehaviour
{

    [Header("REFERENCES")]
    public GameObject UIObject;         //  Reference to the GameObject that contains the UIScript
    public GameObject trackBuilder;     //  Reference to the GameObject that holds the trackBuilder script   


    private void Awake()
    {
        // Find the trackBuilder gameObject by using its tag
        // Give UIObject a value
        trackBuilder = GameObject.FindWithTag("TrackBuilder");

        // Find the trackBuilder gameObject by using its tag
        // Give UIObject a value
        UIObject = GameObject.FindWithTag("UIObject");
    }


    private void OnTriggerEnter(Collider other)
    {
        // If an object with the 'Player' tag enters the trigger zone..
        if (other.CompareTag("Player"))
        {
            // Testing
            Debug.Log("Trigger triggered");

            // Increment the counter in UIScript
            UIObject.gameObject.GetComponent<UIScript>().IncrementModuleCount();

            // Ask the TrackBuilder to determine [and then place] the next module
            trackBuilder.GetComponent<TrackBuilder>().SelectNextModule();
        }

    }

}
