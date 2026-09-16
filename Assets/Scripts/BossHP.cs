using System.Collections;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    public float maxHP = 40; // 최대 체력
    private float currentHP; // 현재 체력
    private SpriteRenderer spriteRenderer;
    private Boss boss; // Boss 스크립트 참조

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;


    private void Start()
    {
        currentHP = maxHP; // 현재 체력을 최대 체력과 같게 설정
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<Boss>(); // Boss 스크립트 참조를 얻어옴
    }

    public void TakeDamage(float damage)
    {
        // 현재 체력을 damage만큼 감소
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);  //11.12

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // 체력이 0이하 = 보스 캐릭터 사망
        if (currentHP <= 0)
        {
            // 체력이 0이면 Boss 스크립트의 Die() 함수를 호출해서 죽었을 때 처리를 한다
            boss.Die();
           // Debug.Log("Boss HP : 0.. Die");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // 적의 색상을 빨간색으로
        spriteRenderer.color = Color.red;
        // 0.05초 동안 대기
        yield return new WaitForSeconds(0.05f);
        // 적의 색상을 원래 색상인 하얀색으로
        spriteRenderer.color = Color.white;
    }
}
