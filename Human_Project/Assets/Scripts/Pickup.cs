using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    /* Allows Person to pick up trash
     */

    public bool isTrash;
    public bool isBanana;
    public bool isBottle;
    public GameObject Person;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Person.gameObject.GetComponent<Inventory>().trashes != 0 | Person.gameObject.GetComponent<Inventory>().bananas != 0 | Person.gameObject.GetComponent<Inventory>().bottles != 0)
            {
                return;
            }
            else
            {
                if (isTrash == true)
                {
                    Person.gameObject.GetComponent<Inventory>().trashes++;
                }
                if (isBanana == true)
                {
                    Person.gameObject.GetComponent<Inventory>().bananas++;

                }
                if (isBottle == true)
                {
                    Person.gameObject.GetComponent<Inventory>().bottles++;

                }
                Destroy(gameObject);
            }
        }
    }
}
