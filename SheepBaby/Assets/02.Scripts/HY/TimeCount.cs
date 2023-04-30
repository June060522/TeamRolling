using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class TimeCount : MonoBehaviour
{
    public static TimeCount Instance;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI dayCntText;
    [SerializeField] private Light2D globalLight;

    public float timer;
    public int dayCnt = 1;
    public bool isNight = false;

    private const float dayChange = 29f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("TimeCount is Multiple");

        Time.timeScale = 1;
    }

    void Start()
    {
        globalLight.intensity = 1;
        dayCnt = 1;
        //StartCoroutine(DayCnt());
    }

    public void Update()
    {
        timer += Time.deltaTime;
        timeText.text = $"{Mathf.FloorToInt(timer / 60)} : {Mathf.FloorToInt(timer % 60)}";

        dayCntText.text = $"Day {Mathf.FloorToInt(timer / 60)}";
        if (Mathf.FloorToInt(timer % 60) > 29)
        {
            isNight = true;
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, 0.3f, 0.02f);
        }
        else
        {
            isNight = false;
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, 1.1f, 0.02f);
        }

        if(!isNight && Mathf.FloorToInt(timer % 60) > 29) 
            StartCoroutine(WolfSpawn.wolfSpawn.WolfStart());
    }

    IEnumerator DayCnt()
    {
        while (globalLight.intensity < 1)
        {
            isNight = true;
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, 1.1f, 0.2f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(dayChange);

        while (globalLight.intensity > 0.4f)
        {
            isNight = false;
            globalLight.intensity = Mathf.Lerp(globalLight.intensity, 0.3f, 0.2f);
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(WolfSpawn.wolfSpawn.WolfStart());
        yield return new WaitForSeconds(dayChange);

        dayCnt++;
        StartCoroutine(DayCnt());
    }
}
