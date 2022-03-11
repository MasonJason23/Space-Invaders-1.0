using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Aliens : MonoBehaviour
{
    public Enemy[] prefabs;
    public Vector3 direction = Vector3.right;
    public ScoreManager scoreManager;
    public int row = 5;
    public int col = 11;
    public float movementSpd = 1;
    public float movementDelay = 1;
    public float rowAdvanceY = 1;
    
    private float accumulatedTime = 0f;
    private float delayShorten;
    private int totalAliens;
    private int enemyShootDelay = 1;
    private float enemyWait = 0f;

    private void Awake()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Enemy alien = Instantiate(this.prefabs[i], this.transform);
                // alien.enemyDied += updateScore;
                float newX = alien.transform.position.x + j;
                float newY = alien.transform.position.y + i;
                alien.transform.position = new Vector2(newX, newY);
            }
        }
        totalAliens = GetComponentsInChildren<Enemy>().Length;
    }

    private void Start()
    {
        delayShorten = 0;
        scoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        delayShorten = (1f - ((GetComponentsInChildren<Enemy>().Length - 0.01f) / totalAliens)) / 1.2f;
        
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > (movementDelay - delayShorten))
        {
            this.transform.position += (direction * movementSpd);
            accumulatedTime = 0f;
        }

        enemyWait += Time.deltaTime;
        if (enemyWait >= enemyShootDelay)
        {
            enemyWait = 0;
            // ToDo: Fix Transform out of bounds error
            // int randomIndex = Mathf.RoundToInt(Random.Range(0, totalAliens-1));
            // Transform enemyChild = this.gameObject.transform.GetChild(randomIndex);
            // randomIndex = Mathf.RoundToInt(Random.Range(0, totalAliens-1));
            // Transform enemyChild1 = this.gameObject.transform.GetChild(randomIndex);
            // randomIndex = Mathf.RoundToInt(Random.Range(0, totalAliens-1));
            // Transform enemyChild2 = this.gameObject.transform.GetChild(randomIndex);
            // if (enemyChild != null)
            // {
            //     enemyChild.GetComponent<Enemy>().enemyShoot();
            // }
            // if (enemyChild1 != null)
            // {
            //     enemyChild1.GetComponent<Enemy>().enemyShoot();
            // }
            // if (enemyChild2 != null)
            // {
            //     enemyChild2.GetComponent<Enemy>().enemyShoot();
            // }
        }

        foreach (Transform alien in this.transform)
        {
            if (!alien.gameObject.activeInHierarchy)
            {
                continue;
            }
            else if (Math.Abs(alien.transform.position.x) > 11f)
            {
                this.transform.position =
                    new Vector3(this.transform.position.x, this.transform.position.y - rowAdvanceY, 0f);
                direction.x *= -1;
                this.transform.position += (direction * movementSpd);
                break;
            }
        }
    }

    private void updateScore()
    {
        // Ask how to refer to enemy after listening to enemy died event
        // scoreManager.updateScore();
    }
}
