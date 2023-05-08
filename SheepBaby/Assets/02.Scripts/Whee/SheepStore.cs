using JetBrains.Annotations;
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
    {
        paperText.text = paper.ToString();
    }

    public void BuySheep(SheepPriceData sheepPriceData)
    {
        float sheetCnt = GameObject.FindGameObjectsWithTag("Sheep").Length;

        if (paper > 0 && sheetCnt < 10)
        {
            paper -= sheepPriceData.price;
            PlayerPrefs.SetFloat("Paper", paper);

            GameObject newSheep = Instantiate(sheepPriceData.sheep);
            //GameObject newSheep = Instantiate(sheepPriceData.sheep, new Vector3(Random.Range(-5f, 6f), -0.02f, 0), Quaternion.identity);

            newSheep.GetComponent<SheepMove>().enabled = false;
            newSheep.GetComponent<SheepAbiliity>().enabled = false;

            newSheep.transform.parent = sheepEmple.transform;
            newSheep.tag = "Sheep";
        }

        int d = sheepEmple.transform.childCount;
        Debug.Log(d);
        List<GameObject> allSheep = new List<GameObject>();

        for (int i = 0; i < d; i++)
            allSheep.Add(sheepEmple.transform.GetChild(i).gameObject);

        allSheep.Sort((a, b) => a.name.CompareTo(b.name));

        for (int i = 0; i < d; i++)
            allSheep[i].transform.position = new Vector3(-(d / 2) + (i * 1.5f), 0, 0);
    }

    public void GameStart()
    {
        if(sheepEmple.transform.childCount > 0)
            SceneManager.LoadScene("DevWheesung");
    }
}
