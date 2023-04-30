using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaterMinigame : MonoBehaviour
{
    public static WaterMinigame instance;

    [SerializeField] Scrollbar scrollbar;
    [SerializeField] RectTransform goal;

    bool gameEnd = false;
    bool isDir = true;
    float moveVal = 0f;
    float goalVal = 0f;
    private void Awake()
    {
        instance = this;

        if(scrollbar == null)
        {
            scrollbar = GetComponent<Scrollbar>();
        }

        scrollbar.interactable = false;
    }

    private void OnEnable()
    {
        gameEnd = false;
        StartMinigame(1f, 3f);
    }

    public void StartMinigame(float length, float speed)
    {
        SetGoal();
        StartCoroutine(CoStart(speed));
        StartCoroutine(CoStart(speed));
    }
    public void SetGoal()
    {
        goalVal = Random.Range(0.2f, 0.8f);
        goal.anchoredPosition = new Vector2((goalVal * 400) - 15,0);
    }
    IEnumerator CoStart(float speed)
    {
        while(true)
        {
            if (Input.GetMouseButtonDown(0))
                break;
            if(isDir)
            {
                moveVal = Mathf.Clamp(moveVal + speed / 1000, 0, 1);
                if(moveVal == 1)
                    isDir = false;
            }
            else
            {
                moveVal = Mathf.Clamp(moveVal - speed / 1000, 0, 1);
                if (moveVal == 0)
                {
                    isDir = true;
                }
            }
            scrollbar.value = moveVal;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        gameEnd = true;
    }

    public bool EndGame(out float value)
    {
        if (gameEnd)
        {
            Debug.Log(33);
            float endVal = moveVal - goalVal;
            if (endVal >= -0.12 && endVal <= 0.03)
            {
                Debug.Log("1.5น่");
                value = 30;
                return true;
            }
            else if (endVal >= -0.12 && endVal <= 0.1)
            {
                Debug.Log("1น่");
                value = 20;
                return true;
            }
            else
            {
                Debug.Log("0.5น่");
                value = 10;
                return true;
            }
        }
        value = 0;
        return false;
    }
}