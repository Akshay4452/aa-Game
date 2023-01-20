using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreDisplay;
    [SerializeField] public TMP_Text highScoreDisplay;
    
    void Start() 
    {
        scoreDisplay.enabled = true;
        highScoreDisplay.enabled = true;
        DisplayScores();
    }
    
    void DisplayScores()
    {
        // storing the high score
        int highScore = PlayerPrefs.GetInt(ScoreHandler.highScoreKey, 0);
        // display the high score
        highScoreDisplay.text = $"High Score : {highScore}";
        
        // similarly display the current score
        int currentScore = PlayerPrefs.GetInt(ScoreHandler.currentScoreKey, 0);
        scoreDisplay.text = $"Score : {currentScore}";
    }
}
