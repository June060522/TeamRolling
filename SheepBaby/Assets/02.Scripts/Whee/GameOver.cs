using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static GameOver gameOver;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeReference] private Text gameoverText;

    void Awake() => gameOver = this;

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
        TimeCount.Instance.enabled = false;
        panel.SetActive(true);
        gameoverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
