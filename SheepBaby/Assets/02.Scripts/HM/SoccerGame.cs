using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    public float speed = 10f; // �౸�� �̵� �ӵ�
    public Vector2 KeyInput;
    public float currentPower;

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
        //float moveVertical = Input.GetAxis("Vertical"); // �յ� �̵�

        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f); // �̵� ���� ����
        rb.AddForce(movement * speed); // �̵� �ӵ��� ���� ���� ���� �౸�� �̵�
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(KeyInput.normalized * currentPower, ForceMode2D.Impulse);
        }
    }
}
