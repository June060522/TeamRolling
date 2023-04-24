using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Starping : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] private Text WinText;
    [SerializeField] private SoccerGame soccerGame;

    static public bool gameEnd = false;
    static public float gameValue;

    private void Awake()
    {
        WinText.enabled = false;
        //soccerGame = FindObjectOfType<SoccerGame>();
        soccerGame.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        WinText.enabled = true;
        if (collision.transform.tag == "Goal")
        {
            WinText.text = "Goal!!";
            gameValue = 40;
            Debug.Log("½Â¸®");
        }
       else
        {
            WinText.text = "NoGoal..";
            gameValue = 0;
            rb.velocity = Vector2.zero;
        }
        gameEnd = true;
        soccerGame.enabled = false;
    }
}
