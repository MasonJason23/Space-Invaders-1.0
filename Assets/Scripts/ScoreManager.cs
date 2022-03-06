using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private TextMeshProUGUI highScore;
    private static int score;
    private static int topScore;
    private static bool scoreChange;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        topScore = PlayerPrefs.GetInt("highScore");
        scoreChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreChange)
        {
            playerScore.text = "0";
            int size = score.ToString().Length;
            if (size < 3)
            {
                playerScore.text += "0";
            }
            playerScore.text += score.ToString();
            scoreChange = false;
        }
    }

    public static void updateScore(string enemyType)
    {
        scoreChange = true;
        if (enemyType.Equals("E1"))
        {
            score += 10;
        }
        else if (enemyType.Equals("E2"))
        {
            score += 20;
        }
        else if (enemyType.Equals("E3"))
        {
            score += 30;
        }
        else
        {
            return;
        }

        if (score > topScore)
        {
            PlayerPrefs.SetInt("highScore",score);
        }
    }
}
