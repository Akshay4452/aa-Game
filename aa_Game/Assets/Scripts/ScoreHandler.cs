using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance; // Singleton pattern on score handler
    public TMP_Text scoreText;
    public int score = 0;
    public const string highScoreKey = "Highscore";
    public const string currentScoreKey = "CurrentScore";

    void Start()
    {
        scoreText.enabled = true;
    }

    public void scoreUpdate()
    {
        score++;
        scoreText.text = score.ToString();
    }
    private void OnDestroy() 
    {
        // code for setting high score
        int currentHighscore = PlayerPrefs.GetInt(highScoreKey, 0);
        if(score > currentHighscore)
        {
            PlayerPrefs.SetInt(highScoreKey, Mathf.FloorToInt(score));
        }

        // code for setting current score
        int currentScore = PlayerPrefs.GetInt(currentScoreKey, 0);
        if(score > 0)
        {
            PlayerPrefs.SetInt(currentScoreKey, Mathf.FloorToInt(score));
        }
    }
}