using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGame : MonoBehaviour
{
    /*public Transform ArrowTrm;
    public Transform PowerBarTrm;*/

    public float speed = 10f; // �౸�� �̵� �ӵ�
    public Vector2 KeyInput;
    private float MaxPower = 40, chargSpeed = 20;
    public float CurrnetPower = 0;
    bool a = true;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // �౸���� Rigidbody ������Ʈ ��������
    }

    void Update()
    {
        if(a)
            BallMove();
        Shoot();
    }

    public void BallMove()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // �¿� �̵�
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f); // �̵� ���� ����
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
        rb.velocity = Vector2.zero; // ���� �ӵ� �ʱ�ȭ

        // �ڿ������� �Ŀ� ���
        float power = Mathf.Pow(CurrnetPower / MaxPower, 2) * MaxPower;

        // ������ �ӵ��� �������� �ӵ��� �����ϸ� AddForce ��� velocity ���� ���
        //rb.velocity = transform.up * shootSpeed * power;
        CurrnetPower = 0;
    }*/
}
