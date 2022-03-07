using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float movementSpd;
    
    private string mTag;
    
    // Start is called before the first frame update
    void Start()
    {
        mTag = this.gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (Vector3.right * movementSpd * Time.deltaTime);

        if (this.transform.position.x >= 11f)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager.updateScore(this.gameObject.tag);
        Destroy(this.gameObject);
    }
}
