using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacleLeft : MonoBehaviour
{
    public float Speed { get; set; }

    void Update()
    {
        transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);

        //장애물이 화면 바깥으로 나가면 제거
        if (transform.position.x < -13.0f)
        {
            Destroy(gameObject);
        }
    }
}