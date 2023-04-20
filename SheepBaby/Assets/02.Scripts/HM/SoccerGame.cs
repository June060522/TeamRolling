using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    public float speed = 10f; // �౸�� �̵� �ӵ�
    public Vector2 KeyInput;
    private float MaxPower = 15, chargSpeed = 20;
    private float CurrnetPower = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �౸���� Rigidbody ������Ʈ ��������
    }

    void FixedUpdate()
    {
        BallMove();
        Shoot();
    }

    public void BallMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // �¿� �̵�
        float moveVertical = Input.GetAxis("Vertical"); // �յ� �̵�

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f); // �̵� ���� ����
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
