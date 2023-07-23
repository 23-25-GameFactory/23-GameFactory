using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 6.0f; // 점프력
    [SerializeField] private float jumpDistance = 2.0f; // 점프 거리
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 jumpDirection = new Vector2(horizontalInput * jumpDistance, jumpForce);
            rb.AddForce(jumpDirection, ForceMode2D.Impulse); // 점프 실행
        }
    }
}