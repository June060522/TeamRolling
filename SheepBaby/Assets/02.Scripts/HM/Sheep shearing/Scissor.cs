using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scissor : MonoBehaviour
{
    public GameObject fur; // 깎을 양 모델
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
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 위치를 가져옴
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // 마우스 위치에서 Raycast 발사

        if (hit.collider != null && hit.collider.gameObject == fur) // 깎을 양 모델을 클릭했다면
        {
            int cutAmount = Random.Range(minCut, maxCut + 1); // 깎을 양을 랜덤으로 결정
            for (int i = 0; i < cutAmount; i++)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(hit.point, 0.2f); // 깎을 위치 주변에 있는 Collider들을 가져옴
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject == fur) // 깎을 양 모델에 닿았다면
                    {
                        Destroy(collider.gameObject); // 해당 양을 파괴
                        break;
                    }
                }
            }
        }
    }*/
}
