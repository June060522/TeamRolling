using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    [SerializeField] bool isBall;
    [SerializeField] TextMeshProUGUI NoGoalText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NoGoal();
    }

    private void NoGoal()
    {
        if (isBall == true)
        {

        }
    }
}
