using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    public float speed = 10f; // 축구공 이동 속도
    public Vector2 KeyInput;
    private float MaxPower = 15, chargSpeed = 20;
    private float CurrnetPower = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 축구공의 Rigidbody 컴포넌트 가져오기
    }

    void FixedUpdate()
    {
        BallMove();
        Shoot();
    }

    public void BallMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // 좌우 이동
        float moveVertical = Input.GetAxis("Vertical"); // 앞뒤 이동

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f); // 이동 벡터 생성
        rb.velocity = new Vector3(moveHorizontal * speed, 0f, 0f);
    }

    private void Shoot()
    {
        Fire();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CurrnetPower += chargSpeed * Time.deltaTime;
            CurrnetPower = Mathf.Clamp(CurrnetPower, 0, MaxPower);
        }
        
    }

    private void Fire()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(KeyInput.normalized * CurrnetPower, ForceMode2D.Impulse);
        CurrnetPower = 0;
    }
}
