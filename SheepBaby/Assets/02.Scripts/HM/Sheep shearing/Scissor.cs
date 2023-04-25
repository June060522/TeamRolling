using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scissor : MonoBehaviour
{
    public GameObject fur; // ���� �� ��
    public int RandomInt = 10;
    private float scissorSpeed = 100;

    public TextMeshProUGUI RandomText;

    private void Start()
    {
        FarRandom();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, scissorSpeed * Time.deltaTime);
    }

    private void FarRandom()
    {
        RandomInt = Random.Range(0, 10);
        RandomText.text = $"{RandomInt}";
    }
    /*private void OnMouseDown()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ġ�� ������
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // ���콺 ��ġ���� Raycast �߻�

        if (hit.collider != null && hit.collider.gameObject == fur) // ���� �� ���� Ŭ���ߴٸ�
        {
            int cutAmount = Random.Range(minCut, maxCut + 1); // ���� ���� �������� ����
            for (int i = 0; i < cutAmount; i++)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(hit.point, 0.2f); // ���� ��ġ �ֺ��� �ִ� Collider���� ������
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject == fur) // ���� �� �𵨿� ��Ҵٸ�
                    {
                        Destroy(collider.gameObject); // �ش� ���� �ı�
                        break;
                    }
                }
            }
        }
    }*/
}
