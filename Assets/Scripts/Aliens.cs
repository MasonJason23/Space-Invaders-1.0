using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public Enemy[] prefabs;
    public int row = 5;
    public int col = 11;

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
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
