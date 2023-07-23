using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private GameObject cloudPrefab1;
    private GameObject cloudPrefab2;
    [SerializeField]
    private float spawnTime;

    private void Awake()
    {
        StartCoroutine("SpawnCloud");
    }

    private IEnumerator SpawnCloud()
    {
        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x + 3.0f, stageData.LimitMax.x);
            Vector3 spawnPosition = new Vector3(positionX, stageData.LimitMax.y - 2.0f, -1.0f); // y값을 2.0만큼 낮춘다
            Instantiate(cloudPrefab1, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

}