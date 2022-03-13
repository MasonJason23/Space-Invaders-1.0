using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform offset;
    public event Action<GameObject> EnemyDied;
    private GameObject m_Shot;
    
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("Missile"))
        {
            if (EnemyDied != null)
            {
                EnemyDied(gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
