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
        gameoverText.text = "양들을 잘 관리하지않아 죽었어요!";
    }

    public void HuntedOver()
    {
        BaseOver();
        gameoverText.text = "양들이 늑대에게 잡아먹혔어요!";
    }

    public void BurnOutOver()
    {
        BaseOver();
        gameoverText.text = "소년이 지쳐서 더 이상 양들을 돌볼 수 없어요!";
    }

    private void BaseOver()
    {
        TimeCount.Instance.enabled = false;
        panel.SetActive(true);
        gameoverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
