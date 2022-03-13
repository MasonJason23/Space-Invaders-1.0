using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform offset;
    public event Action<GameObject> EnemyDied;

    private ParticleSystem enemyParticleSystem;
    private Animator enemyAnimator;
    private GameObject m_Shot;
    private Collider2D enemyCollider2D;
    private static readonly int Death = Animator.StringToHash("Death");

    private void Start()
    {
        enemyParticleSystem = GetComponent<ParticleSystem>();
        enemyAnimator = GetComponent<Animator>();
        enemyCollider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Player.setActive)
        {
            return;
        }
        if (m_Shot != null)
        {
            Destroy(m_Shot, 3f);
        }
    }

    public void EnemyShoot()
    {
        m_Shot = Instantiate(bullet, offset.position, Quaternion.identity);
        enemyParticleSystem.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(enemyCollider2D);
        if (!collision.gameObject.tag.Equals("Missile"))
        {
            if (EnemyDied != null)
            {
                EnemyDied(gameObject);
            }
            enemyAnimator.SetBool(Death, true);
            Destroy(this.gameObject, 0.6f);
        }
    }
}
