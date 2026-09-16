using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10; // 최대 체력
    private float currentHP;  // 현재 체력
    private SpriteRenderer spriteRenderer;
    private PlayerController PlayerController;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;


    private void Awake()
    {
        currentHP = maxHP; // currentHP를 maxHP로 초기화
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlayerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        // 현재 체력을 damage 만큼 감소
        currentHP -= damage;
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        // 체력이 0 이하 = 플레이어 캐릭터 사망
        if (currentHP <= 0)
        {
            // 체력이 0이하 = 플레이어 캐릭터 사망
            PlayerController.OnDie();
           // Debug.Log("Player HP : 0.. Die");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // 플레이어의 색상을 빨간색으로 
        spriteRenderer.color = Color.red;
        // 0.1초 동안 대기
        yield return new WaitForSeconds(0.1f);
        // 플레이어의 색상을 원래 색상인 하얀색으로
        // (원래 색상이 하얀색이 아닐 경우 원래 색상 변수 선언)
        spriteRenderer.color = Color.white;
    }
}
