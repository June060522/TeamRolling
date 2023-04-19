using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    public float speed = 10f; // 축구공 이동 속도

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 축구공의 Rigidbody 컴포넌트 가져오기
    }

    void FixedUpdate()
    {
        BallMove();
    }

    private void BallMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // 좌우 이동
        float moveVertical = Input.GetAxis("Vertical"); // 앞뒤 이동

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); // 이동 벡터 생성
        rb.AddForce(movement * speed); // 이동 속도에 따라 힘을 가해 축구공 이동
    }

    private void Shoot()
    {
        
    }
}
