using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;
using UnityEditor;
using TMPro;
using static UnityEngine.Rendering.DebugUI;
using System;

public class GameStartManager : MonoBehaviour
{
    [SerializeField] GameObject sheep;
    [SerializeField] GameObject sheepEmple;
    [SerializeField] private TextMeshProUGUI inputText;

    void Awake()
        => DontDestroyOnLoad(sheepEmple);

    //public void SheepSetting()
    //{
    //    string s = inputText.text[0].ToString();

    //    try
    //    {
    //        if (inputText.text.Length < 3)
    //        {
    //            SheepAbiliity[] oldSheep = FindObjectsOfType<SheepAbiliity>();
    //            foreach (SheepAbiliity oSheep in oldSheep)
    //                Destroy(oSheep.gameObject);

    //            float pos = -(float.Parse(s) - 1) / 2;
    //            for (float i = pos; i <= -pos; i += 1f)
    //            {
    //                GameObject newSheep = Instantiate(sheep, new Vector3(i, -0.02f, 0), Quaternion.identity);
    //                newSheep.transform.parent = sheepEmple.transform;
    //                newSheep.tag = "Sheep";
    //            }
    //        }
    //    }
    //    catch (Exception exp) { }
    //}

    //public void StartWheeSong()
    //{
    //    string s = inputText.text[0].ToString();

    //    PlayerPrefs.SetFloat("SheepAmount", int.Parse(s));

    //    if (int.Parse(s) > 0 && int.Parse(s) < 10 && inputText.text.Length < 3)
    //        SceneManager.LoadScene("DevWheesung");
    //}

    public void InputSheep(GameObject sheep)
    {
        GameObject newSheep = Instantiate(sheep, new Vector3(0, -0.02f, 0), Quaternion.identity);
        newSheep.transform.parent = sheepEmple.transform;
        newSheep.tag = "Sheep";
    }
}
