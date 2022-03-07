using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action playerDied;
    public GameObject bullet;
    public Transform shottingOffset;
    [Range (1f, 100f)]
    public float movementSpd;
    
    private Rigidbody2D rbody2D;
    private float horizontalMovement;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        shoot();
    }

    void FixedUpdate()
    {
        rbody2D.velocity = new Vector2(horizontalMovement * movementSpd, 0);
    }

    void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);

            Destroy(shot, 3f);
        }
    }
}
