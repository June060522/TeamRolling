using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOver;

    private BoyAbiliity boyAbiliity;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeReference] private Text gameoverText;

    void Awake()
    {
        gameOver = this;
        boyAbiliity = FindObjectOfType<BoyAbiliity>();
    }

    public void StateOver()
    {
        BaseOver();
        gameoverText.text = "����� �� ���������ʾ� �׾����!";
    }

    public void HuntedOver()
    {
        BaseOver();
        gameoverText.text = "����� ���뿡�� ��Ƹ������!";
    }

    public void BurnOutOver()
    {
        BaseOver();
        gameoverText.text = "�ҳ��� ���ļ� �� �̻� ����� ���� �� �����!";
    }

    private void BaseOver()
    {
        float paperAmount = PlayerPrefs.GetFloat("Paper") + boyAbiliity.paper;
        PlayerPrefs.SetFloat("Paper", paperAmount);

        panel.SetActive(true);
        gameoverPanel.SetActive(true);

        TimeCount.Instance.enabled = false;
        Time.timeScale = 0f;
    }
}
