using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] public GameObject obstaclePrefab; // 장애물 프리팹 연결
    [SerializeField] public float minSpawnInterval = 4.0f; // 최소 생성 간격
    [SerializeField] public float maxSpawnInterval = 5.0f; // 최대 생성 간격
    [SerializeField] public float speed= 5.0f; // 장애물 이동 속도
    [SerializeField] public int maxObstacleCount = 4; // 최대 생성

    [SerializeField] public GameObject textBossWarning; // 보스 등장 텍스트 오브젝트

    [SerializeField] private GameObject boss;


    void Start()
    {
        // 보스 등장 텍스트 비활성화
        textBossWarning.SetActive(false);
        boss.SetActive(false);
        StartCoroutine("SpawnObstacle");
    }

    IEnumerator SpawnObstacle()
    {
        int obstacleCount = 0; // 생성된 장애물의 개수를 추적하는 변수

        while (obstacleCount < maxObstacleCount)
        {
            // 화면 오른쪽 끝 위치 계산
            Vector3 viewportRightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
            float spawnXPosition = viewportRightEdge.x;

            // 장애물 생성 위치 설정
            Vector3 spawnPosition = new Vector3(spawnXPosition, -2.0f, transform.position.z);

            // 장애물 생성
            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // ObstacleScroller 스크립트를 장애물에 추가
            ObstacleScroller obstacleScroller = newObstacle.GetComponent<ObstacleScroller>();
            if (obstacleScroller == null)
            {
                obstacleScroller = newObstacle.AddComponent<ObstacleScroller>();
            }

            obstacleScroller.moveSpeed = speed; // 장애물 이동 속도 설정
 
            obstacleCount++; // 장애물 개수 증가

            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
        if (obstacleCount == maxObstacleCount)
        {
            // 최대 장애물 개수에 도달하면 보스 등장 텍스트 표시
            textBossWarning.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            textBossWarning.SetActive(false);
            boss.SetActive(true);
        }
    }
}