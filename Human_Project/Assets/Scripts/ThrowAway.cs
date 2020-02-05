using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAway : MonoBehaviour
{
    /* Allows the Person to empty their inventory when colliding with the bin matching the trash
     */
    public bool TrashBin;
    public bool EcoBin;
    public bool GlassBin;
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
                if (TrashBin == true)
                {
                    if (Person.gameObject.GetComponent<Inventory>().trashes != 0)
                    {
                        Person.gameObject.GetComponent<Inventory>().trashes--;
                    }
                }
                if (EcoBin == true)
                {
                    if (Person.gameObject.GetComponent<Inventory>().bananas != 0)
                    {
                        Person.gameObject.GetComponent<Inventory>().bananas--;
                    }

                }
                if (GlassBin == true)
                {
                    if (Person.gameObject.GetComponent<Inventory>().bottles != 0)
                    {
                        Person.gameObject.GetComponent<Inventory>().bottles--;
                    }
                }
                Destroy(gameObject);
            }
        }
    }
}