using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    public float moveSpeed = 5f; // 골키퍼 이동 속도
    public Transform ballTransform; // 축구공의 Transform
    public bool Ball;

    private Rigidbody2D rb;
    private bool isMovingLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Blocking();
    }

    void FixedUpdate()
    {
        // 골키퍼 좌우 이동
        float moveHorizontal = isMovingLeft ? -1f : 1f; // 이전 방향으로 이동
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rb.MovePosition(transform.position + moveSpeed * Time.fixedDeltaTime * movement);

        // 축구공과의 거리 계산
        //float distance = Vector3.Distance(transform.position, ballTransform.position);

        // 이동 방향 전환
        if (transform.position.x > 3f) // 오른쪽 벽에 닿으면 왼쪽으로 이동
        {
            isMovingLeft = true;
        }
        else if (transform.position.x < -3f) // 왼쪽 벽에 닿으면 오른쪽으로 이동
        {
            isMovingLeft = false;
        }
    }

    public void Blocking()
    {
        if(Ball == true)
        {
            Debug.Log("막았다");
        }

        else
        {
            Debug.Log("못 막았다");
        }
    }
}
