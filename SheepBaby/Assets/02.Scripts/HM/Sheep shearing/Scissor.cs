using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Scissor : MonoBehaviour
{
    public GameObject fur; // ±ðÀ» ¾ç ¸ðµ¨
    public int RandomInt = 10;
    private float scissorSpeed = 100;
    private int FarCount;
    private float timer = 15;

    public TextMeshProUGUI RandomText;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI EndText;
    public TextMeshProUGUI FailText;
    public TextMeshProUGUI TimeText;

    private void Start()
    {
        FarRandom();
    }

    private void Update()
    {
        Move();
        CountTime();
    }

    private void CountTime()
    {
        timer -= Time.deltaTime;
        TimeText.text = "³²Àº½Ã°£ : " + Mathf.Round(timer);
        if(timer <= 0)
        {
            FailText.text = "failure";
            enabled = false;
        }
    }

    private void Move()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, scissorSpeed * Time.deltaTime);
    }

    public void FarRandom()
    {
        RandomInt = UnityEngine.Random.Range(1, 10);
        RandomText.text = $"{RandomInt}";
    }

    IEnumerator DeilyTime(float _deilyTime, Action collback)
    {
        yield return new WaitForSeconds(_deilyTime);
        collback?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Far"))
        {
            Destroy(collision.gameObject);
            FarCount++;
            CountText.text = $"{FarCount}";
            if(FarCount == RandomInt)
            {
                StartCoroutine(DeilyTime(1, () =>
                {
                    EndText.text = "Clear";
                    enabled = false;
                }));

            }
        }
    }
}
