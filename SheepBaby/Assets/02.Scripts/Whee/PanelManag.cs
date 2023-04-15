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

    [SerializeField] private Text thirstText;
    [SerializeField] private Text hungryText;
    [SerializeField] private Text stressText;
    [SerializeField] private Text tiredText;

    private void Awake()
    {
        sheeps = FindObjectsOfType<SheepMove>();
        boy = FindObjectOfType<Boy>();
    }

    void Update()
    {
        if (boy.isChose)
        {
            BoyText();
        }
        else
        {
            foreach (SheepMove sheep in sheeps)
            {
                if (sheep.isChose)
                    SheepText(sheep.gameObject.GetComponent<SheepAbiliity>());
            }
        }
    }

    void BoyText()
    {

    }

    void SheepText(SheepAbiliity sheep)
    {
        tiredText.text = sheep.Thirst.ToString();
        hungryText.text = sheep.Hungry.ToString();
        stressText.text = sheep.Stress.ToString();
    }
}
