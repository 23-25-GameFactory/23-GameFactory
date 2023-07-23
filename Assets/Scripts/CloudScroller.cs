using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScroller : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.left;
    void Update()
    {
        // 구름이 moveDirecion 방향으로 moveSpeed 의 속도로 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}