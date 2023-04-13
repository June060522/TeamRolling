using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    public float timer;

    void Start()
    {

    }

    public void Update()
    {
        timer += Time.deltaTime;
        timeText.text = $"{timer:N2}";
    }
}
