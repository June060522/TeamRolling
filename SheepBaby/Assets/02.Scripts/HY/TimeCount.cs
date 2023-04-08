using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;

    public float timer;

    private PanelManager panelManager;

    void Start()
    {
        panelManager = GetComponent<PanelManager>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        timeText.text = $"{timer:N2}";
    }
}
