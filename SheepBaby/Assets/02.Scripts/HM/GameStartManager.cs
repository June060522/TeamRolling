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

    public void InputSheep(GameObject sheep)
    {
        GameObject newSheep = Instantiate(sheep, new Vector3(UnityEngine.Random.Range(-5f, 6f), -0.02f, 0), Quaternion.identity); ;

        newSheep.GetComponent<SheepMove>().enabled = false;
        newSheep.GetComponent<SheepAbiliity>().enabled = false;

        newSheep.transform.parent = sheepEmple.transform;
        newSheep.tag = "Sheep";
    }
}
