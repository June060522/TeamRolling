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

    private bool isWaiting = false;
    private bool isClear = false;
    private bool isFail = false;

    public TextMeshProUGUI RandomText;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI EndText;
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
            EndText.color = Color.red;
            EndText.text = "failure";
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Far"))
        {
            Destroy(collision.gameObject);
            FarCount++;
            CountText.text = $"{FarCount}";
            if (FarCount == RandomInt)
            {
                if (!isWaiting)
                {
                    isWaiting = true;
                    StartCoroutine(DeilyTime(1, () =>
                    {
                        if (FarCount > RandomInt)
                        {
                            isFail = true;
                            isClear = false;
                        }
                        else
                        {
                            isClear = true;
                            isFail = false;
                        }
                        EndText.text = isClear ? "Clear" : "Fail";
                        enabled = false;
                    }));
                }
            }
        }
    }

    private IEnumerator DeilyTime(float seconds, Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
    }
}
