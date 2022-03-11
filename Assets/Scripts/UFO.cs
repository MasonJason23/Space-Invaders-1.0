using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float movementSpd;
    public event Action<GameObject> UfoDied;

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
        Destroy(this.gameObject);
        if (UfoDied != null)
        {
            UfoDied(gameObject);
        }
    }
}
