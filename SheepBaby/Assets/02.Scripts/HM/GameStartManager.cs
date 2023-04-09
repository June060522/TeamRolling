using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    [SerializeField] GameObject SelectModPanel;
    [SerializeField] GameObject Title;

    public void OnGameStartButton()
    {
        SelectModPanel.SetActive(true);
        Title.SetActive(false);
    }

    public void EasyMod()
    {
        SceneManager.LoadScene(0);
    }

    public void NormalMod()
    {
        SceneManager.LoadScene(0);
    }

    public void HardMod()
    {
        SceneManager.LoadScene(0);
    }

    public void Xbutton()
    {
        SelectModPanel.SetActive(false);
        Title.SetActive(true);
    }
}
