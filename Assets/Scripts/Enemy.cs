using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform offset;
    
    private string mTag;
    private float shootingFrequency;
    private float shootingDelay;
    private float accumulatedTime;
    private GameObject shot;

    private void Start()
    {
        mTag = this.gameObject.tag;
        shootingDelay = 1f;
        accumulatedTime = 0f;
        
        switch (mTag)
        {
            case "E1":
                // not frequent
                shootingFrequency = 0.05f;
                break;
            case "E2":
                // basic
                shootingFrequency = 0.10f;
                break;
            case "E3":
                // frequent
                shootingFrequency = 0.20f;
                break;
        }
    }

    private void Update()
    {
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime >= shootingDelay)
        {
            accumulatedTime = 0f;
            if (Random.value < shootingFrequency)
            {
                shot = Instantiate(bullet, offset.position, Quaternion.identity);
            }
        }

        if (shot != null)
        {
            Destroy(shot, 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("Missile"))
        {
            ScoreManager.updateScore(this.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
