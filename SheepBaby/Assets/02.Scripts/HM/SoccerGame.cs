using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    public float speed = 10f; // �౸�� �̵� �ӵ�

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �౸���� Rigidbody ������Ʈ ��������
    }

    void FixedUpdate()
    {
        BallMove();
    }

    private void BallMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // �¿� �̵�
        float moveVertical = Input.GetAxis("Vertical"); // �յ� �̵�

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); // �̵� ���� ����
        rb.AddForce(movement * speed); // �̵� �ӵ��� ���� ���� ���� �౸�� �̵�
    }

    private void Shoot()
    {
        
    }
}
