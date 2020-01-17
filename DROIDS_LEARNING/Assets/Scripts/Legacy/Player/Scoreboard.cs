using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [Header("SCOREBOARD")]
    public int playerScore;

    [Header("PUBLIC REFERENCES")]
    public Text playerScoreText;

    public void Start()
    {
        // Give playerScore an initial value
        playerScore = 0;

        // Give playerScoreText an initial value
        playerScoreText.text = "" + playerScore;
    }

    public void addPoints(int pointsValue)
    {
        playerScore += pointsValue;
        playerScoreText.text = "" + playerScore;
    }
}

