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

    //이거는 뭐하는 아이임? 그냥 값만 바꾸고 할거면 없애기 그리고 활성화 비교가 필요한거면
    //gameObject.activeSelf를 사용하고
    public bool isSetActive = false;

    //이거 왜 받아옴?
    //private TimeCount timeCount;

    private void Awake()
    {
        //timeCount = GetComponent<TimeCount>();
        isSetActive = false;
    }

    //함수명은 관례적으로 첫글자를 대문자로 작성해야함
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

    public void ReStartClick() 
    {
        
        SceneManager.LoadScene("DevWheesung");

    }

    public void ExitBtnClick()
    {

        SceneManager.LoadScene("DevHMin");

    }
}
