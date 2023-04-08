using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject optionPanel;

    private TimeCount timeCount;

    void Start()
    {
        timeCount = GetComponent<TimeCount>();
    }

    void Update()
    {
        
    }

    public void storeBtnClick()
    {
        storePanel.SetActive(true);
        Time.timeScale = 0f;
        //EditorApplication.isPaused = true;
    }

    public void OptionBtnClick()
    {
        optionPanel.SetActive(true);
        Time.timeScale = 0f;
        //EditorApplication.isPaused = true;
    }

    public void CloseStoreBtnClick()
    {
        //EditorApplication.isPaused = false;
        storePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CloseOptionBtnClick()
    {
        //EditorApplication.isPaused = false;
        optionPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
