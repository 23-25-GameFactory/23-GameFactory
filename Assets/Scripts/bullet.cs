using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHP>().TakeDamage(damage);
            //collision.GetComponent<Boss>().Die();
            Destroy(gameObject); // Bullet 프리팹을 제거합니다.
        }
      /* else if (collision.CompareTag("BossBullet"))
        {
            Destroy(collision.gameObject); // BossBullet 프리팹을 제거합니다.
        }*/
    }
}