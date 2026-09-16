using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BossPrefab;
    public float spawnTime = 0.5f;

    //[SerializeField] public GameObject textBossWarning; // 보스 등장 텍스트 오브젝트

    [SerializeField] private GameObject bossHPSliderPrefab;
    [SerializeField] private Transform canvasTransform;

    //[SerializeField] private ObstacleSpawner obstacleSpawner; //11.12

    void Start()
    {
        //textBossWarning.SetActive(false);
        // 코루틴 실행
        StartCoroutine("SpawnBoss");
        //obstacleSpawner = GetComponent<ObstacleSpawner>();//11.12

        //StartCoroutine(SpawnBossWithDelay());
    }

    private IEnumerator SpawnBoss()
    {
        while (true)
        {
            float positionX = 5f;
            Vector3 position = new Vector3(positionX, 0.28f, 0);
            GameObject bossclone = Instantiate(BossPrefab, position, Quaternion.identity);
            SpawnBossHPSlider(bossclone);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnBossHPSlider(GameObject boss)
    {
        GameObject sliderClone = Instantiate(bossHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(boss.transform);
        sliderClone.GetComponent<BossHPViewer>().Setup(boss.GetComponent<BossHP>());
    }


    /*IEnumerator SpawnBossWithDelay()
    {
        // 일정 시간(딜레이)만큼 기다립니다.
        // yield return new WaitForSeconds(spawnTime);

       // yield return StartCoroutine(obstacleSpawner.WairForObstacles()); //11.12

        //textBossWarning.SetActive(true);
       // yield return new WaitForSeconds(1.0f);
       // textBossWarning.SetActive(false);

        // 보스 생성 위치를 설정해주세요.
        Vector3 spawnPosition = new Vector3(5f, -0.1f, 0f);

        // 보스 생성
       GameObject boss = Instantiate(BossPrefab, spawnPosition, Quaternion.identity);
    }*/
}