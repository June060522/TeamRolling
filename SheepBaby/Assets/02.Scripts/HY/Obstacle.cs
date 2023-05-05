using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed=2f;
    [SerializeField] float initSpeed=3f;
    [SerializeField] GameObject[] obstacle = new GameObject[2];
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] TextMeshProUGUI scoreTxt;

    private Rigidbody2D rb;

    int scoreCnt = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = initSpeed;
    }

    private void Update()
    {
        ScoreCnt();

        if (MinigameSheep.isGame)
        {
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

    private void ScoreCnt()
    {
        if (MinigameSheep.isGame)
        {
            scoreCnt += 1;
            scoreTxt.text = "score: " + scoreCnt.ToString();
        }
        else if (!MinigameSheep.isGame)
        {
            scoreCnt += 0;
            scoreTxt.text = "score: " + scoreCnt.ToString();
        }
    }

    private void Move(GameObject obj)
    {
        if (!MinigameSheep.isGame)
            return;

        obj.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
    }

    public void Restart()
    {
        Debug.Log("Restart");
        MinigameSheep.isGame = true;
        speed = initSpeed;
        scoreCnt = 0;

        for (int i = 0; i < 2; i++)
        {
            obstacle[i].transform.position = new Vector3((i * 8) + i,
                obstacle[i].transform.position.y, 0);
        }
        gameoverPanel.gameObject.SetActive(false);
    }
}
