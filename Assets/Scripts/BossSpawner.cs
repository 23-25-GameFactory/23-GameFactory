using System.Collections;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public float spawnDelay = 10f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(spawnDelay);

        // 보스 생성 위치를 설정해주세요.
        Vector3 spawnPosition = new Vector3(10f, 0f, 0f);

        // 보스 생성
        GameObject boss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
    }
}