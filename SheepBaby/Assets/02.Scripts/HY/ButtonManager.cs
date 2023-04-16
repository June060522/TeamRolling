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

    //�̰Ŵ� ���ϴ� ������? �׳� ���� �ٲٰ� �ҰŸ� ���ֱ� �׸��� Ȱ��ȭ �񱳰� �ʿ��ѰŸ�
    //gameObject.activeSelf�� ����ϰ�
    public bool isSetActive = false;

    //�̰� �� �޾ƿ�?
    //private TimeCount timeCount;

    private void Awake()
    {
        //timeCount = GetComponent<TimeCount>();
        isSetActive = false;
    }

    //�Լ����� ���������� ù���ڸ� �빮�ڷ� �ۼ��ؾ���
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
