using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    public float moveSpeed = 5f; // ��Ű�� �̵� �ӵ�
    public float jumpForce = 5f; // ��Ű�� ���� ��
    public float jumpInterval = 3f; // ��Ű�� ���� ����
    public Transform ballTransform; // �౸���� Transform

    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool isMovingLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // ��Ű�� �¿� �̵�
        float moveHorizontal = isMovingLeft ? -1f : 1f; // ���� �������� �̵�
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rb.MovePosition(transform.position + moveSpeed * Time.fixedDeltaTime * movement);

        // �౸������ �Ÿ� ���
        float distance = Vector3.Distance(transform.position, ballTransform.position);

        // ��Ű�� ����
        if (!isJumping && distance < 2f && Random.value < 0.1f) // ���� Ȯ���� ����
        {
            isJumping = true;
            StartCoroutine(JumpCoroutine());
        }

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

    IEnumerator JumpCoroutine()
    {
        yield return new WaitForSeconds(jumpInterval);

        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        isJumping = false;
    }
}
