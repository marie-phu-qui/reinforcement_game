using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // PUBLIC REFERENCES
    public Text timerText;
    public Text formerTimeText;


    // PRIVATE VARS
    private float timer;
    private float startTime;
    private float formerTime;
    private bool finished = false;


    // Start is called before the first frame update
    void Start()
    {
        // Give startTime a value / tie to game clock
        startTime = Time.time;
    }

 
    // Update is called once per frame
    void Update()
    { 
        // If the run has finished
        if (finished)
        {
            TimerReset();
        }

        timer = Time.time - startTime;
        string seconds = (timer % 60).ToString("f2"); //f2 : only 2 decimals after the dot
        timerText.text = seconds;
    }

    public void Finish()
    {
        formerTime = timer;
        finished = true;

        formerTimeText.gameObject.SetActive(true);
        formerTimeText.color = Color.green;

        string seconds = (timer % 60).ToString("f2"); //f2 : only 2 decimals after the dot

        formerTimeText.text = seconds;
    }

    void TimerReset()
    {
        startTime = Time.time;
        finished = false;
    }

}
