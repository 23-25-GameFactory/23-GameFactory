using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // 총알 프리팹
    [SerializeField] private float fireRate = 0.5f; // 발사 간격
    [SerializeField] private float bulletSpeed = 8.0f; // 총알 속도

    [SerializeField]
    private int damage = 1;

    private float nextFireTime = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            FireBullet(); // 스페이스바를 누르면 총알 발사
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * bulletSpeed; // 총알이 오른쪽으로 발사
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            collision.GetComponent<BossHP>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}