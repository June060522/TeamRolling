using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameSheep : MonoBehaviour
{
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] TextMeshProUGUI scoreTxt;

    private Obstacle obstacle;

    private Rigidbody2D rb;

    private float jumpPower = 5f;
    private int scoreCnt = 0;
    private int jumpCnt = 1;

    public bool isGround = true;
    public bool isGame = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGame)
        {
            scoreCnt += 1;
            scoreTxt.text = "score: " + scoreCnt.ToString();
        }
        else if (!isGame)
        {
            scoreCnt += 0;
            scoreTxt.text = "score: " + scoreCnt.ToString();
        }

        if (Input.GetKeyDown("space") && isGround)
        {
            if (jumpCnt == 1)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isGround = false;
                jumpCnt = 0;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            jumpCnt = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
        jumpCnt = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGame = false;
        gameoverPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
