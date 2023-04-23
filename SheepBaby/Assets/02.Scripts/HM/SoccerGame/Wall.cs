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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SetActive(false);
        if (isBall)
        {
            NoGoalText.text = "NoGoal";
            collision.gameObject.SetActive(true);
        }
        else
        {
            NoGoalText.text = "";
        }


    }

    // Update is called once per frame
    void Update()
    {
        NoGoal();
    }

    private void NoGoal()
    {
        
    }
}
