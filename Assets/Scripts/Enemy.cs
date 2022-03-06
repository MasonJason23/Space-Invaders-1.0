using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string mTag;

    private void Start()
    {
        mTag = this.gameObject.tag;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager.updateScore(this.gameObject.tag);
        Destroy(this.gameObject);
    }
}
