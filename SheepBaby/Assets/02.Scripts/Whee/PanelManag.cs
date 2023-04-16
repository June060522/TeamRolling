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

    [SerializeField] private GameObject sheepUI, boyUI;

    [SerializeField] private Text thirstText;
    [SerializeField] private Text hungryText;
    [SerializeField] private Text stressText;
    [SerializeField] private Text tiredText;

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
        if (boy.isChose)
        {
            BoyText();
            sheepUI.SetActive(false);
            boyUI.SetActive(true);
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
                }
            }
        }
    }

    void BoyText()
    {
        tiredText.text = boyAbiliity.tired.ToString();
    }

    void SheepText(SheepAbiliity sheep)
    {
        thirstText.text = sheep.Thirst.ToString();
        hungryText.text = sheep.Hungry.ToString();
        stressText.text = sheep.Stress.ToString();
    }
}
