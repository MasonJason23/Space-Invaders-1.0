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
    public static bool setActive;

    private Animator playerAnimator;
    private Rigidbody2D rbody2D;
    private float horizontalMovement;
    private static readonly int Death = Animator.StringToHash("Death");

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        setActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (setActive)
        {
            return;
        }
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerDied != null)
        {
            playerDied();
        }

        setActive = true;
        playerAnimator.SetBool(Death, true);
        playerAnimator.Play("Player Death");
        Destroy(gameObject, 1.1f);
    }
}
