using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] obstacle = new GameObject[2];
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] TextMeshProUGUI scoreTxt;

    public bool isGame = true;
    int scoreCnt = 0;

    private void Update()
    {
        if (isGame)
        {
            speed = 2f;

            for (int i = 0; i < 2; i++)
            {
                Move(obstacle[i]);
                if (obstacle[i].transform.position.x < -14)
                {
                    obstacle[i].transform.position = new Vector3(7, obstacle[i].transform.position.y, 0);
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

        for (int i = 0; i < 2; i++)
        {
            obstacle[i].transform.position = new Vector3((i * 8) + i,
                obstacle[i].transform.position.y, 0);
        }
        gameoverPanel.gameObject.SetActive(false);
    }
}
