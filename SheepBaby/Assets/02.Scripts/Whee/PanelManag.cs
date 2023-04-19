using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelManag : MonoBehaviour
{
    SheepMove[] sheeps;
    Boy boy;
    BoyAbiliity boyAbiliity;

    [Header("PanelObject")]
    [SerializeField] private GameObject sheepUI, boyUI;
    [SerializeField] private GameObject sheepPrefit, boyPrefit;

    [Header("SheepText")]
    [SerializeField] private Text thirstText;
    [SerializeField] private Text hungryText;
    [SerializeField] private Text stressText;

    [Header("BoyText")]
    [SerializeField] private Text tiredText;
    [SerializeField] private Text paperText;

    private void Awake()
    {
        sheeps = FindObjectsOfType<SheepMove>();
        boy = FindObjectOfType<Boy>();
        boyAbiliity = FindObjectOfType<BoyAbiliity>();
    }

    void Update()
    {
        PanelBrain();
    }

    void PanelBrain()
    {
        BoyText();
        if (boy.isChose)
        {
            sheepUI.SetActive(false);
            boyUI.SetActive(true);
            sheepPrefit.SetActive(false);
            boyPrefit.SetActive(true);
        }
        else
        {
            foreach (SheepMove sheep in sheeps)
            {
                if (sheep.isChose)
                {
                    SheepText(sheep.gameObject.GetComponent<SheepAbiliity>());

                    sheepUI.SetActive(true);
                    boyUI.SetActive(false);
                    sheepPrefit.SetActive(true);
                    boyPrefit.SetActive(false);
                }
            }
        }
    }

    void BoyText()
    {
        tiredText.text = $"Tired : {Mathf.RoundToInt(boyAbiliity.tired)}";
        paperText.text = $"Paper : {Mathf.RoundToInt(boyAbiliity.paper)}";
    }

    void SheepText(SheepAbiliity sheep)
    {
        thirstText.text = $"Thirst : {Mathf.RoundToInt(sheep.Thirst)}";
        hungryText.text = $"Hungry : {Mathf.RoundToInt(sheep.Hungry)}";
        stressText.text = $"Stress : {Mathf.RoundToInt(sheep.Stress)}";
    }
}
