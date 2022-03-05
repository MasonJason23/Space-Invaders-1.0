using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public Enemy[] prefabs;
    public int row = 5;
    public int col = 11;
    public float movementSpd = 1;
    public float movementDelay = 1;
    public float rowAdvanceY = 1;
    public Vector3 direction = Vector3.right;
    
    private float accumulatedTime = 0f;
    private int totalAliens = 0;
    private void Awake()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Enemy alien = Instantiate(this.prefabs[i], this.transform);
                float newX = alien.transform.position.x + j;
                float newY = alien.transform.position.y + i;
                alien.transform.position = new Vector2(newX, newY);
                totalAliens++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > movementDelay)
        {
            this.transform.position += (direction * movementSpd);
            accumulatedTime = 0f;
        }

        foreach (Transform alien in this.transform)
        {
            if (!alien.gameObject.activeInHierarchy)
            {
                continue;
            }
            else if (Math.Abs(alien.transform.position.x) > 11f)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - rowAdvanceY, 0f);
                direction.x *= -1;
                this.transform.position += (direction * movementSpd);
                break;
            }
        }
    }
}
