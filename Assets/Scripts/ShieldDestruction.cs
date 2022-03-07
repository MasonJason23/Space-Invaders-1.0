using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDestruction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
