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

    private GameObject shot;
    private AudioSource playerAudioSrc;
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
        playerAudioSrc = GetComponent<AudioSource>();
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
        if (Input.GetButtonDown("Fire1") && shot == null)
        {
            shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            muzzleAnimator.SetTrigger(Shoot);
            playerAudioSrc.Play();

            Destroy(shot, 1.8f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerDied != null)
        {
            playerDied();
        }
        
        setActive = true;
        playerParticles.Stop();
        playerAnimator.SetBool(Death, true);
        Destroy(gameObject, 1.1f);
    }
}
