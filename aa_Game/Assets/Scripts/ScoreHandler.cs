using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public TMP_Text scoreText;
    int score = 0;

    void Start()
    {
        scoreText.enabled = true;
    }

    public void scoreUpdate()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
