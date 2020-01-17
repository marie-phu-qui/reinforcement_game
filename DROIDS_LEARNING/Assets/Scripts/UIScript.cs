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

    [Header("DEBUG")]
    public int modsReached = 0;
    public int nextMod;
    public bool randomModeOn = true;


    private void Update()
    {
        // Keep UI updated
        modsReachedText.text = "" + modsReached;
        nextModText.text = "" + nextMod;

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


    public void UpdateNextModText(int newNextMod)
    {
        nextMod = newNextMod;
    }

    public void SwitchRandomMode(bool newRandomState)
    {
        randomModeOn = newRandomState;
    }

}
