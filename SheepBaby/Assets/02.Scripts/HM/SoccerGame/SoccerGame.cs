using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    /*public Transform ArrowTrm;
    public Transform PowerBarTrm;*/

    public float speed = 10f; // 축구공 이동 속도
    public Vector2 KeyInput;
    private float MaxPower = 40, chargSpeed = 20;
    public float CurrnetPower = 0;
    bool a = true;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // 축구공의 Rigidbody 컴포넌트 가져오기
    }

    void Update()
    {
        if(a)
            BallMove();
        Shoot();
    }

    public void BallMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // 좌우 이동
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f); // 이동 벡터 생성
        rb.velocity = movement.normalized * speed;
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CurrnetPower += chargSpeed * Time.deltaTime;
            CurrnetPower = Mathf.Clamp(CurrnetPower, 0, MaxPower);
            //Debug.Log(CurrnetPower);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            a = false;
            rb.AddForce(transform.up * 1 * CurrnetPower,ForceMode2D.Impulse);
            //Fire();
        }
        //PowerBarTrm.localScale = new Vector3(CurrnetPower / MaxPower, 1, 1);
    }

    /*private void Fire()
    {
        rb.velocity = Vector2.zero; // 현재 속도 초기화

        // 자연스러운 파워 계산
        float power = Mathf.Pow(CurrnetPower / MaxPower, 2) * MaxPower;

        // 일정한 속도로 나가도록 속도를 조정하며 AddForce 대신 velocity 값을 사용
        //rb.velocity = transform.up * shootSpeed * power;
        CurrnetPower = 0;
    }*/
}
