using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject BossbulletPrefab; // 총알 프리팹
    public Transform firePoint; // 발사 위치

    public float bulletSpeed = 5.5f; // 총알 속도 설정
    public float attackDelay = 111.5f; // 공격 사이의 딜레이 시간 설정
    private bool isAttacking = false; // 현재 공격 중인지 확인하는 플래그 설정

    void Update()
    {
        if (!isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        int attackPattern = Random.Range(0, 3); // 0부터 2까지의 랜덤한 숫자를 생성합니다.

        switch (attackPattern)
        {
            case 0:
                // 첫 번째 공격 패턴 코드
                int numBulletsInLine = 3; // 일직선으로 생성할 총알 수
                float spacing = 0.4f; // 총알 간격

                for (int i = 0; i < numBulletsInLine; i++)
                {
                    Vector2 spawnPosition = new Vector2(firePoint.position.x, firePoint.position.y + i * spacing);
                    GameObject bullet = Instantiate(BossbulletPrefab, spawnPosition, Quaternion.identity);
                    Vector2 bulletDirection = Vector2.left;
                    bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed; // 총알 속도 설정
                }
                Debug.Log("Performing Attack Pattern 1");
                break;

            case 1:
                // 두 번째 공격 패턴 코드 (왼쪽으로 이동하면서 커지는 원 모양)
                int numBulletsInCircle = 14; // 원 모양에 생성할 총알 수
                float circleRadius = 0.7f; // 초기 반지름
                float circleSpeed = 0.8f; // 반지름 증가 속도

                for (int i = 0; i < numBulletsInCircle; i++)
                {
                    float angle = i * 360f / numBulletsInCircle; // 각도 계산
                    float radians = angle * Mathf.Deg2Rad; // 각도를 라디안으로 변환

                    Vector2 bulletDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)); // 방향 설정
                    Vector2 spawnPosition = new Vector2(firePoint.position.x - circleRadius, firePoint.position.y);

                    GameObject bullet = Instantiate(BossbulletPrefab, spawnPosition, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed; // 총알 속도 설정

                    circleRadius += circleSpeed; // 반지름 증가
                }
                Debug.Log("Performing Attack Pattern 2");
                break;

            case 2:
                // 세 번째 공격 패턴 코드 (일직선으로 나가면서 뱀처럼 회전)
                int numSegments = 5; // 뱀 모양 웨이브의 세그먼트 수
                float segmentSpacing = 0.5f; // 세그먼트 간격
                float rotationSpeed = 140f; // 회전 속도 (1초에 60도)

                for (int i = 0; i < numSegments; i++)
                {
                    Vector2 spawnPosition = new Vector2(firePoint.position.x - i * segmentSpacing, firePoint.position.y);
                    GameObject bullet = Instantiate(BossbulletPrefab, spawnPosition, Quaternion.identity);
                    Vector2 bulletDirection = Quaternion.Euler(0, 0, i * rotationSpeed * Time.deltaTime) * Vector2.left;
                    bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed; // 총알 속도 설정
                }
                Debug.Log("Performing Attack Pattern 3");
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(attackDelay);

        isAttacking = false;
    }
}