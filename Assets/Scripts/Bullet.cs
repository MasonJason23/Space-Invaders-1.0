using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;
  private string mTag;

  public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
      mTag = gameObject.tag;
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
      
      FindObjectOfType<Player>().playerDied += OnPlayerDeath;
    }

    // Update is called once per frame
    private void Fire()
    {
      if (mTag.Equals("Bullet"))
      {
        myRigidbody2D.velocity = Vector2.up * speed;
      }
      else if (mTag.Equals("Missile"))
      {
        myRigidbody2D.velocity = Vector2.down * speed * 0.5f;
      }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
      if (!col.gameObject.name.Equals("Player") && mTag.Equals("Bullet"))
      {
        Destroy(gameObject);
      }
      
      if (col.gameObject.name.Equals("Player") && mTag.Equals("Missile"))
      {
        Destroy(gameObject);
      }
    }
    
    public void OnPlayerDeath()
    {
      FindObjectOfType<Player>().playerDied -= OnPlayerDeath;
      Destroy(gameObject);
    }
}
