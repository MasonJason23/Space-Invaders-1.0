using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI highScoreText;
    
    private static int playerScore;
    private static int highScore;
    private static bool scoreChange;
    private static bool highScoreChange;
    
    void Start()
    {
        playerScore = 0;
        if (PlayerPrefs.GetInt("highScore") != 0)
        {
            highScore = PlayerPrefs.GetInt("highScore");
            updateUIScore(highScoreText, highScore);
        }
        else
        {
            highScore = 0;
        }
        scoreChange = false;
        highScoreChange = false;
    }
    
    void Update()
    {
        if (scoreChange)
        {
            if (highScoreChange)
            {
                updateUIScore(highScoreText, highScore);
            }
            updateUIScore(playerScoreText, playerScore);
            scoreChange = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("highScore", 0);
        }
    }

    public static void updateScore(string enemyType)
    {
        scoreChange = true;
        if (enemyType.Equals("E1"))
        {
            playerScore += 10;
        }
        else if (enemyType.Equals("E2"))
        {
            playerScore += 20;
        }
        else if (enemyType.Equals("E3"))
        {
            playerScore += 30;
        }
        else
        {
            return;
        }

        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("highScore",playerScore);
            highScore = playerScore;
            if (!highScoreChange)
            {
                highScoreChange = true;
            }
        }
    }

    private void updateUIScore(TextMeshProUGUI element, int score)
    {
        element.text = "0";
        int size = score.ToString().Length;
        if (size < 3)
        {
            element.text += "0";
        }
        element.text += score.ToString();
    }
}
