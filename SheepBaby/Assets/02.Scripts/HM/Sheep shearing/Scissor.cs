using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.EventSystems;

public class Scissor : MonoBehaviour, IDragHandler
{
    public static Scissor instance;

    public GameObject fur; // ���� �� ��
    public int RandomInt;
    private float scissorSpeed = 100;
    private int FarCount;
    private float timer;

    private bool isWaiting = false;
    private bool isClear = false;
    private bool isFail = false;

    public TextMeshProUGUI TimeText;

    private void Awake() => instance = this;

    private void OnEnable()
    {
        timer = 15;
        RandomInt = 15;
        FarCount = 0;
    }

    private void Update()
    {
        CountTime();
    }

    private void CountTime()
    {
        timer -= Time.deltaTime;
        TimeText.text = Mathf.Round(timer).ToString();
    }

    public bool EndGame(out float value)
    {
        if (timer <= 0)
        {
            value = 0;
            return true;
        }
        else if (FarCount == RandomInt)
        {
            value = Mathf.Ceil(timer / 3);
            return true;
        }

        value = 0;
        return false;
    }

    private void Move()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, scissorSpeed * Time.deltaTime);
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
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
