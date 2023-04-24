using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;

public class GameStartManager : MonoBehaviour
{
    [SerializeField] GameObject SelectModPanel;
    [SerializeField] GameObject Title;
    [SerializeField] Text inputText;

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

    public void StartWheeSong()
    {
        PlayerPrefs.SetFloat("SheepAmount", int.Parse(inputText.text));
        if (int.Parse(inputText.text) > 0 && int.Parse(inputText.text) <= 10)
            SceneManager.LoadScene("DevWheesung");
    }
}
