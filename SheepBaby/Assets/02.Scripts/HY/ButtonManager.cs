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


    private void Awake()
    {
        //timeCount = GetComponent<TimeCount>();
    }

    public void storeBtnClick()
    {
        storePanel.SetActive(true);
        optionButton.interactable = false;
        Time.timeScale = 0f;
    }

    public void OptionBtnClick()
    {
        optionPanel.SetActive(true);
        storeButton.interactable = false;
        Time.timeScale = 0f;
    }

    public void CloseStoreBtnClick()
    {
        storePanel.SetActive(false);
        optionButton.interactable = true;
        Time.timeScale = 1f;
    }

    public void CloseOptionPanel()
    {
        optionPanel.SetActive(false);
        storeButton.interactable = true;
        Time.timeScale = 1f;

    }

    public void ReStartClick() 
    {
        
        SceneManager.LoadScene("DevWheesung");

    }

    public void ExitBtnClick()
    {

        SceneManager.LoadScene("DevHMin");

    }
}
