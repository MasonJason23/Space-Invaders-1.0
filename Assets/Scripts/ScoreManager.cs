using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

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

        FindObjectOfType<Player>().playerDied += OnPlayerDeath;
        Enemy[] enemyArray = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemyArray.Length; i++)
        {
            enemyArray[i].EnemyDied += OnEnemyDeath;
        }

        FindObjectOfType<SpawnUFO>().UfoSpawn += GetUfoDeathEvent;
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
            updateUIScore(highScoreText, 0);
        }
    }

    private void updateUIScore(TextMeshProUGUI element, int score)
    {
        element.text = "";
        int size = score.ToString().Length;
        while (size < 4)
        {
            element.text += "0";
            size++;
        }
        element.text += score.ToString();
    }

    private void OnEnemyDeath(GameObject enemy)
    {
        scoreChange = true;
        if (enemy.name.Equals("Tier 1(Clone)"))
        {
            playerScore += 10;
        }
        else if (enemy.name.Equals("Tier 2(Clone)"))
        {
            playerScore += 20;
        }
        else if (enemy.name.Equals("Tier 3(Clone)"))
        {
            playerScore += 30;
        }
        else
        {
            int randomPtValue = Mathf.RoundToInt(Random.Range(1, 5));
            switch (randomPtValue)
            {
                case 1:
                    playerScore += 50;
                    break;
                case 2:
                    playerScore += 100;
                    break;
                case 3:
                    playerScore += 150;
                    break;
                case 4:
                    playerScore += 200;
                    break;
                default:
                    playerScore += 250;
                    break;
            }
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

    void GetUfoDeathEvent()
    {
        FindObjectOfType<UFO>().UfoDied += OnEnemyDeath;
    }

    private void OnPlayerDeath()
    {
        Time.timeScale = 0;
    }
}
