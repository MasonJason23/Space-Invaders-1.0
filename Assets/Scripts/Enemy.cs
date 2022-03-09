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
    private GameObject shot;

    private void Start()
    {
        mTag = this.gameObject.tag;
    }

    private void Update()
    {
        if (shot != null)
        {
            Destroy(shot, 3f);
        }
    }

    public void enemyShoot()
    {
        shot = Instantiate(bullet, offset.position, Quaternion.identity);
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
