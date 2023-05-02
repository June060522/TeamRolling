using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.EventSystems;

public class Scissor : MonoBehaviour, IDragHandler
{
    public GameObject fur; // ±ðÀ» ¾ç ¸ðµ¨
    public int RandomInt = 10;
    private float scissorSpeed = 100;
    private int FarCount;
    private float timer = 15;

<<<<<<< Updated upstream
    public TextMeshProUGUI RandomText;
    public TextMeshProUGUI CountText;
=======
    private bool isWaiting = false;
    private bool isClear = false;
    private bool isFail = false;

>>>>>>> Stashed changes
    public TextMeshProUGUI EndText;
    public TextMeshProUGUI FailText;
    public TextMeshProUGUI TimeText;

    private void Start()
    {
        FarRandom();
    }

    private void Update()
    {
        //Move();
        CountTime();
    }

    private void CountTime()
    {
        timer -= Time.deltaTime;
        TimeText.text = Mathf.Round(timer).ToString();
        if(timer <= 0)
        {
            FailText.text = "failure";
            enabled = false;
        }
    }

    public bool EndGame()
    {
        return false;
    }

    private void Move()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, scissorSpeed * Time.deltaTime);
    }

    public void FarRandom()
        => RandomInt = UnityEngine.Random.Range(1, 10);

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
<<<<<<< Updated upstream
            CountText.text = $"{FarCount}";
            if(FarCount == RandomInt)
=======
            if (FarCount == RandomInt)
>>>>>>> Stashed changes
            {
                StartCoroutine(DeilyTime(1, () =>
                {
                    EndText.text = "Clear";
                    enabled = false;
                }));
            }
        }
    }
<<<<<<< Updated upstream
=======

    private IEnumerator DeilyTime(float seconds, Action callback)
    {
        yield return new WaitForSeconds(seconds);
        callback?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
>>>>>>> Stashed changes
}
