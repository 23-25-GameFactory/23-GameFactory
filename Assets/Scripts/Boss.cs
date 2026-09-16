using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // 이벤트 정의
    public event Action OnDieEvent;

    public BossHP bossHP;

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private int scorePoint = 50;
    private PlayerController playerController;

    [SerializeField]
    private string nextSceneName;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bossHP = GetComponent<BossHP>();
    }

    // 보스가 데미지를 받는 메서드
    public void TakeDamage(float damage)
    {
        if (bossHP != null)
        {
            bossHP.TakeDamage(damage);

            // 체력이 0 이하로 떨어지면 보스가 사라지도록 처리
            if (bossHP.CurrentHP <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        // 보스가 죽었을 때 처리하는 로직을 추가합니다.
        // 예를 들면 보스가 죽는 애니메이션을 재생하거나, 게임 결과 처리를 수행합니다.

        // 죽음 이벤트 호출
        if (OnDieEvent != null)
        {
            OnDieEvent.Invoke();
        }

        playerController.Score += scorePoint; // 11.12
                                              // 보스 오브젝트 제거
        Destroy(gameObject);

        SceneManager.LoadScene("GameClear");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            Die();
        }
    }

    internal void ChangeState(object moveToAppearPoint)
    {
        throw new NotImplementedException();
    }
}
