using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public float movementSpd;
    public event Action<GameObject> UfoDied;

    private Collider2D UfoCollider2D;
    private Animator UfoAnimator;
    private static readonly int Death = Animator.StringToHash("Death");

    private void Start()
    {
        UfoAnimator = GetComponent<Animator>();
        UfoCollider2D = GetComponent<Collider2D>();
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
        UfoAnimator.SetBool(Death, true);
        Destroy(UfoCollider2D);
        Destroy(this.gameObject, 0.6f);
        if (UfoDied != null)
        {
            UfoDied(gameObject);
        }
    }
}
