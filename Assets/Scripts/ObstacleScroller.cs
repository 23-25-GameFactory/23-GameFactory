using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScroller : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 3.0f;
    [SerializeField]
    public Vector3 moveDirection = Vector3.left;
    void Update()
    {
        // ��ֹ��� moveDirecion �������� moveSpeed �� �ӵ��� �̵�
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}