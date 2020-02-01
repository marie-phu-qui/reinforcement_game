using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleTrigger : MonoBehaviour
{

    [Header("REFERENCES")]
    public GameObject UIObject;         //  Reference to the GameObject that contains the UIScript
    public GameObject trackBuilder;     //  Reference to the GameObject that holds the trackBuilder script
    public GameObject currentModule;
    public Transform currentTransform;
    public Transform parentTransform;



    private void Awake()
    {
        // Find the trackBuilder gameObject by using its tag
        // Give UIObject a value
        trackBuilder = GameObject.FindWithTag("TrackBuilder");

        // Find the UI gameObject by using its tag
        // Give UIObject a value
        UIObject = GameObject.FindWithTag("UIObject");


    }

    private void OnTriggerEnter(Collider other)
    {
       
        // If an object with the 'Player' tag enters the trigger zone..
        if (other.CompareTag("Player"))
        {
            // Increment the counter in UIScript
            UIObject.gameObject.GetComponent<UIScript>().IncrementModuleCount();

            // Give THIS module the CurrentModule tag (4 steps)
            currentTransform = gameObject.transform;                                        //  Get the transform component of this trigger object
            parentTransform = currentTransform.transform.parent;                            //  Get the transform of the parent of this trigger object
            currentModule = parentTransform.transform.gameObject;                           //  Get the GameObject the trigger belongs to
            trackBuilder.GetComponent<TrackBuilder>().SetCurrentModule(currentModule);      //  Set the newCurrentModule in Trackbuilder
                                                                                            //  The Trackbuilder will then run the SelectNextModule method 
        }

    }
    private int collision = 0;
    private void OnCollisionReset()
    {
        collision++;
        // Testing
        Debug.Log("Wall Trigger triggered" + collision);


    }

}
