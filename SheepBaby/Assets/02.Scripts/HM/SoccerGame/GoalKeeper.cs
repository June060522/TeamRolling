using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    public float moveSpeed = 5f; // ��Ű�� �̵� �ӵ�
    public Transform ballTransform; // �౸���� Transform
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
        // ��Ű�� �¿� �̵�
        float moveHorizontal = isMovingLeft ? -1f : 1f; // ���� �������� �̵�
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rb.MovePosition(transform.position + moveSpeed * Time.fixedDeltaTime * movement);

        // �౸������ �Ÿ� ���
        //float distance = Vector3.Distance(transform.position, ballTransform.position);

        // �̵� ���� ��ȯ
        if (transform.position.x > 3f) // ������ ���� ������ �������� �̵�
        {
            isMovingLeft = true;
        }
        else if (transform.position.x < -3f) // ���� ���� ������ ���������� �̵�
        {
            isMovingLeft = false;
        }
    }

    public void Blocking()
    {
        if(Ball == true)
        {
            Debug.Log("���Ҵ�");
        }

        else
        {
            Debug.Log("�� ���Ҵ�");
        }
    }
}
