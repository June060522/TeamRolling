using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private Button storeButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private GameObject soundOnButton;
    [SerializeField] private GameObject soundOffButton;

    public bool isSetActive = false;

    private TimeCount timeCount;

    void Start()
    {
        timeCount = GetComponent<TimeCount>();
        isSetActive = false;
    }

    public void storeBtnClick()
    {
        isSetActive = true;
        storePanel.SetActive(true);
        optionButton.interactable = false;
        Time.timeScale = 0f;
    }

    public void OptionBtnClick()
    {
        isSetActive = true;
        optionPanel.SetActive(true);
        storeButton.interactable = false;
        Time.timeScale = 0f;
    }

    public void CloseStoreBtnClick()
    {
        isSetActive = false;
        storePanel.SetActive(false);
        optionButton.interactable = true;
        Time.timeScale = 1f;
    }

    public void CloseOptionPanel()
    {
        isSetActive = false;
        optionPanel.SetActive(false);
        storeButton.interactable = true;
        Time.timeScale = 1f;
    }

    public void SoundOnOff()
    {
        if (AudioListener.volume == 1)
        {
            soundOnButton.SetActive(false);
            soundOffButton.SetActive(true);
            AudioListener.volume = 0;
        }
        else
        {
            soundOnButton.SetActive(true);
            soundOffButton.SetActive(false);
            AudioListener.volume = 1;
        }

    }

    public void ExitBtnClick()
    {
        SceneManager.LoadScene("DevHMin");
    }
}
