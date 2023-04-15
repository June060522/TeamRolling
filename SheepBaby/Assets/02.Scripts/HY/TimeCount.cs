using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class TimeCount : MonoBehaviour
{
    public static TimeCount Instance;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI dayCntText;
    [SerializeField] private Light2D globalLight;

    public float timer;
    public int dayCnt = 1;

    private float dayChange = 30f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("TimeCount is Multiple");
    }

    void Start()
    {
        globalLight.intensity = 1;
        dayCnt = 1;
        StartCoroutine(DayCnt());
    }

    public void Update()
    {
        timer += Time.deltaTime;
        timeText.text = $"{timer:N2}";

        dayCntText.text = $"Day {dayCnt}";
    }

    IEnumerator DayCnt()
    {
        globalLight.intensity = 1;
        Debug.Log("day");
        yield return new WaitForSeconds(dayChange);
        globalLight.intensity = 0.4F;
        Debug.Log("night");
        yield return new WaitForSeconds(dayChange);
        dayCnt++;
        Debug.Log(dayCnt);
        StartCoroutine(DayCnt());
    }
}
