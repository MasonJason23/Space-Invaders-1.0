using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action playerDied;
    public GameObject bullet;
    public GameObject muzzle;
    public Transform shottingOffset;
    [Range (1f, 100f)]
    public float movementSpd;
    public static bool setActive;
    public float shotDelay = 0.5f;
    public float accumulatedTime = 0f;
    public AudioSource playerShootAudio;
    public AudioSource playerDeathAudio;
    
    private Animator playerAnimator;
    private Animator muzzleAnimator;
    private ParticleSystem playerParticles;
    private Rigidbody2D rbody2D;
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    private float horizontalMovement;

    private void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerParticles = GetComponent<ParticleSystem>();
        muzzleAnimator = muzzle.GetComponent<Animator>();
        setActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (setActive)
        {
            rbody2D.velocity = Vector2.zero;
            return;
        }

        accumulatedTime += Time.deltaTime;
        if (Input.GetButton("Horizontal"))
        {
            playerParticles.Play();
        }
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        rbody2D.velocity = new Vector2(horizontalMovement * movementSpd, 0);
        shoot();
    }

    void shoot()
    {
        if (Input.GetButtonDown("Fire1") && accumulatedTime >= shotDelay)
        {
            accumulatedTime = 0f;
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            muzzleAnimator.SetTrigger(Shoot);
            playerShootAudio.Play();

            Destroy(shot, 1.8f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerDied != null)
        {
            playerDied();
        }
        
        playerDeathAudio.Play();
        setActive = true;
        playerParticles.Stop();
        playerAnimator.SetBool(Death, true);
        Destroy(gameObject, 1.1f);
    }
}
