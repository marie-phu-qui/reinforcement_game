using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [Header("REFERENCES")]
    public Text modsReachedText;
    public Text nextModText;
    public Text randomModeText;
    public Text collisionsText;

    [Header("DEBUG")]
    public int modsReached = 0;
    public int collisions = 0;
    public int nextMod;
    public bool randomModeOn = true;


    private void Update()
    {
        // Keep UI updated
        modsReachedText.text = "" + modsReached;
        nextModText.text = "" + nextMod;
        collisionsText.text = "" + collisions;

        if (randomModeOn == true)
        {
            randomModeText.text = ("ON");
        }

        else
        {
            randomModeText.text = ("OFF");
        }
    }


    public void IncrementModuleCount()
    {
        modsReached++;
    }

    public void IncrementCollisionCount()
    {
        collisions++;
    }


    public void UpdateNextModText(int newNextMod)
    {
        nextMod = newNextMod;
    }

    public void SwitchRandomMode(bool newRandomState)
    {
        randomModeOn = newRandomState;
    }

}