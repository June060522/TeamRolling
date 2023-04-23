using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField] bool isBall;
    [SerializeField] TextMeshProUGUI NoGoalText;

    public static Wall Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        NoGoal();
    }

    private void NoGoal()
    {
        if (isBall)
        {
            NoGoalText.text = "NoGoal";
        }
        else
        {
            NoGoalText.text = "";
        }
    }
}
