using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCount : MonoBehaviour
{
    public static TimeCount Instance;

    [SerializeField] private TextMeshProUGUI timeText;

    public float timer;

    private PanelManager panelManager;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("TimeCount is Multiple");
    }
    
    void Start()
    {

    }

    public void Update()
    {
        timer += Time.deltaTime;
        timeText.text = $"{timer:N2}";
    }
}
