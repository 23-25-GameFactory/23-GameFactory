using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; //장애물 프리팹 연결
    [SerializeField] private float minSpawnInterval = 4.0f; //최소 생성 간격
    [SerializeField] private float maxSpawnInterval = 8.0f; //최대 생성 간격
    [SerializeField] private float speed = 2.0f; //장애물 이동 속도

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            // 화면 오른쪽 끝 위치 계산
            Vector3 viewportRightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
            float spawnXPosition = viewportRightEdge.x;

            // 장애물 생성 위치 설정
            Vector3 spawnPosition = new Vector3(spawnXPosition, -2.0f, transform.position.z);

            // 장애물 생성
            GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            newObstacle.AddComponent<MoveObstacleLeft>(); // 이동 스크립트 추가
            newObstacle.GetComponent<MoveObstacleLeft>().Speed = speed;
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }
}