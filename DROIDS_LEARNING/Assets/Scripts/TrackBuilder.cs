using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBuilder : MonoBehaviour
{
    [Header("DEBUG")]
    public bool randomModeOn = true;    //  Whether or not to choose modules randomly
    public int randomNumber;            //  For storing random number
    public GameObject nextModule;       //  Chosen module
    public GameObject lastModule;       //  Previous module
    public bool gameHasBegun = false;   //  The game has begun

    [Header("TRACK MODULES")]
    public GameObject module01;         //  Reference to module prefab
    public GameObject module02;         //  Reference to module prefab
    public GameObject module03;         //  Reference to module prefab 
    public GameObject module04;         //  Reference to module prefab
    /*
    public GameObject module05;         //  Reference to module prefab
    public GameObject module06;         //  Reference to module prefab
    public GameObject module07;         //  Reference to module prefab
    public GameObject module08;         //  Reference to module prefab
    public GameObject module09;         //  Reference to module prefab
    public GameObject module10;         //  Reference to module prefab
    */

    [Header("REFERENCES")]
    public GameObject UIObject;         //  Reference to the GameObject that contains the UIScript
    public Transform firstLocation;     //  Reference to the location to place first module at start of game
    public Transform nextLocation;     //  Reference to the location where the next module should be placed


    
    private void Start()                // This runs at the start of the game
    {
        // Find the trackBuilder gameObject by using its tag
        // Give UIObject a value
        UIObject = GameObject.FindWithTag("UIObject");
    }


    void Update()
    {
        // Only accept numerical key input if game has begun
        if (gameHasBegun == true)
        {
            // If randomMode is switched off
            if (randomModeOn == false)
            {
                // Update the UI (to say that random mode is OFF)
                UIObject.gameObject.GetComponent<UIScript>().SwitchRandomMode(false);

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    // Set the Prefab
                    nextModule = module01;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(1);
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    // Set the Prefab
                    nextModule = module02;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(2);
                }

                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    // Set the Prefab
                    nextModule = module03;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(3);
                }
                
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    // Set the Prefab
                    nextModule = module04;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(4);
                }
                /*
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    // Set the Prefab
                    nextModule = module05;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(5);
                }

                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    // Set the Prefab
                    nextModule = module06;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(6);
                }

                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    // Set the Prefab
                    nextModule = module07;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(7);
                }

                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    // Set the Prefab
                    nextModule = module08;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(8);
                }

                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    // Set the Prefab
                    nextModule = module09;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(9);
                }

                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    // Set the Prefab
                    nextModule = module10;

                    // Tell UIScript which track was selected
                    UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(10);
                }
                */
            }

            else
            {
                // Update the UI (to say that random mode is ON)
                UIObject.gameObject.GetComponent<UIScript>().SwitchRandomMode(true);
            }
        }

    }


    public void SelectNextModule()
    {
        

            if (randomModeOn == true)
            {
                // Choose a random number
                randomNumber = Random.Range(1, 4);
            }

            // Testing
            Debug.Log(randomNumber);


            if (randomNumber == 1)
            {
                // Set the Prefab
                nextModule = module01;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(1);
            }

            else if (randomNumber == 2)
            {
                // Set the Prefab
                nextModule = module02;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(2);
            }

            else if (randomNumber == 3)
            {
                // Set the Prefab
                nextModule = module03;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(3);
            }
            
            else if (randomNumber == 4)
            {
                // Set the Prefab
                nextModule = module04;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(4);
            }
            /*
            else if (randomNumber == 5)
            {
                // Set the Prefab
                nextModule = module05;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(5);
            }

            else if (randomNumber == 6)
            {
                // Set the Prefab
                nextModule = module07;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(6);
            }

            else if (randomNumber == 7)
            {
                // Set the Prefab
                nextModule = module07;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(7);
            }

            else if (randomNumber == 8)
            {
                // Set the Prefab
                nextModule = module08;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(8);
            }

            else if (randomNumber == 9)
            {
                // Set the Prefab
                nextModule = module09;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(9);
            }

            else if (randomNumber == 0)
            {
                // Set the Prefab
                nextModule = module10;

                // Tell UIScript which track was selected
                UIObject.gameObject.GetComponent<UIScript>().UpdateNextModText(10);
            }
            */
            // Place the next module (via the method below)
            PlaceNextModule();
        
    }


    // Places the selected module 
    void PlaceNextModule()
    {
        Debug.Log("Placing selected module");

        
        if (gameHasBegun == false)
        {
            // If the game has NOT begun..
            // Instantiate the selected module at the starting position
            Instantiate(nextModule, firstLocation.position, firstLocation.rotation);

            // Signal that the game has begun
            gameHasBegun = true;
        }

        
        else
        {
            // If the game HAS begun..
            // Find the nextLocation empty by using its tag (and converting to a transform)
            // Give nextLocation a value
            nextLocation = GameObject.FindWithTag("NextLocation").transform;

            // Instantiate the selected module at the next position
            Instantiate(nextModule, nextLocation.position, nextLocation.rotation);

            // Untag this nextLocation object to ensure there is always only one
            nextLocation.gameObject.tag = "Untagged";
        }

    }



}
