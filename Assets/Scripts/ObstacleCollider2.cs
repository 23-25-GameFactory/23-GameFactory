using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider2 : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;  // 
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Boss")) {
            collision.GetComponent<BossHP>().TakeDamage(damage);
        }
    }
}

