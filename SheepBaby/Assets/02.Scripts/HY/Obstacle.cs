using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] ground = new GameObject[2];
    [SerializeField] GameObject obstacle, gameoverPanel;
    [SerializeField] TextMeshProUGUI scoreTxt;

    public static bool isGame = true;
    int scoreCnt = 0;

    private void Update()
    {
        if (isGame)
        {
            speed += 0.1f * Time.deltaTime;

            scoreCnt += 1;
            scoreTxt.text = "score: " + scoreCnt.ToString();

            Move(obstacle);
            if (obstacle.transform.position.x < -15)
            {
                obstacle.transform.position = new Vector3(0, obstacle.transform.position.y, 0);
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
        speed = 1;
        scoreCnt = 0;
        obstacle.transform.position = new Vector3(2, obstacle.transform.position.y, 0);
        gameoverPanel.SetActive(false);
    }
}
