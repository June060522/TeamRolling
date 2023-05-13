using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SheepStore : MonoBehaviour
{
    [Header("sheep")]
    [SerializeField] GameObject sheepEmple;

    [Header("text")]
    [SerializeField] private TextMeshProUGUI paperText;
    private float paper;

    private void Awake()
    {
        DontDestroyOnLoad(sheepEmple);
        paper = PlayerPrefs.GetFloat("Paper");
    }

    private void Update()
        => paperText.text = paper.ToString();

    public void BuySheep(SheepPriceData sheepPriceData)
    {
        float sheetCnt = GameObject.FindGameObjectsWithTag("Sheep").Length;

        if (paper > 0 && sheetCnt < 10)
        {
            paper -= sheepPriceData.price;
            PlayerPrefs.SetFloat("Paper", paper);

            GameObject newSheep = Instantiate(sheepPriceData.sheep, new Vector3(UnityEngine.Random.Range(-5f, 6f), -0.02f, 0), Quaternion.identity); ;

            newSheep.GetComponent<SheepMove>().enabled = false;
            newSheep.GetComponent<SheepAbiliity>().enabled = false;

            newSheep.transform.parent = sheepEmple.transform;
            newSheep.tag = "Sheep";
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("DevWheesung");
    }
}
