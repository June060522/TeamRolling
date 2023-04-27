using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] ground = new GameObject[2];
    [SerializeField] GameObject[] obstacle = new GameObject[3];
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] TextMeshProUGUI scoreTxt;

    public static bool isGame = true;
    int scoreCnt = 0;

    private void Update()
    {
        if (isGame)
        {
            speed=3.5f;

            scoreCnt += 1;
            scoreTxt.text = "score: " + scoreCnt.ToString();

            for (int i = 0; i < 3; i++)
            {
                Move(obstacle[i]);
                if (obstacle[i].transform.position.x < -14)
                {
                    obstacle[i].transform.position = new Vector3(7, obstacle[i].transform.position.y, 0);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                Move(ground[i]);
                if (ground[i].transform.position.x <= -10)
                {
                    ground[i].transform.position = new Vector3(0, ground[i].transform.position.y, 0);
                }
            }
        }
    }

    private void Move(GameObject obj)
    {
        obj.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
    }

    public void Restart()
    {
        isGame = true;
        Time.timeScale = 1f;
        speed = 1;
        scoreCnt = 0;

        for (int i = 0; i < 3; i++)
        {
            obstacle[i].transform.position = new Vector3(Random.Range(0,15),
                obstacle[i].transform.position.y, 0);
        }
        gameoverPanel.SetActive(false);
    }
}
