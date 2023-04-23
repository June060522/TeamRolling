using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningMinigame : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;

    void Start()
    {
        
    }

    void Update()
    {
        GamePanelOn();
    }

    public void GamePanelOn()
    {
        if (Input.GetKeyDown(KeyCode.F))
            gamePanel.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.Escape))
            gamePanel.SetActive(false);
    }
}
