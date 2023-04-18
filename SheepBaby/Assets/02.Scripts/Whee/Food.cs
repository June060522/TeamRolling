using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public static Food Instance;

    [SerializeField] private Text moistureText;
    [SerializeField] private Text foodText;

    public float moisture;
    public float food;

    void Awake() => Instance = this;

    private void Update()
    {
        moistureText.text = moisture.ToString();
        foodText.text = food.ToString();
    }
}
