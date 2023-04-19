using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    public float moveSpeed = 5f; // 골키퍼 이동 속도
    public float jumpForce = 5f; // 골키퍼 점프 힘
    public float jumpInterval = 3f; // 골키퍼 점프 간격
    public Transform ballTransform; // 축구공의 Transform

    private Rigidbody rb;
    private bool isJumping = false;
    private bool isMovingLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 골키퍼 좌우 이동
        float moveHorizontal = isMovingLeft ? -1f : 1f; // 이전 방향으로 이동
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);

        // 축구공과의 거리 계산
        float distance = Vector3.Distance(transform.position, ballTransform.position);

        // 골키퍼 점프
        if (!isJumping && distance < 2f && Random.value < 0.1f) // 일정 확률로 점프
        {
            isJumping = true;
            StartCoroutine(JumpCoroutine());
        }

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

    IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(jumpInterval);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = false;
    }
}
