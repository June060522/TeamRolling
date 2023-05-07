using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOver;

    private BoyAbiliity boyAbiliity;

    private GameObject sheepEmplx;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeReference] private Text gameoverText;

    void Awake()
    {
        gameOver = this;
        boyAbiliity = FindObjectOfType<BoyAbiliity>();
    }

    void Start()
        => sheepEmplx = GameObject.FindWithTag("SheepEmplx");

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
        float paperAmount = boyAbiliity.paper;
        PlayerPrefs.SetFloat("Paper", paperAmount);

        Destroy(sheepEmplx);

        panel.SetActive(true);
        gameoverPanel.SetActive(true);

        TimeCount.Instance.enabled = false;
        Time.timeScale = 0f;
    }
}
