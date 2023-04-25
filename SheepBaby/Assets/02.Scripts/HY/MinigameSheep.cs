using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSheep : MonoBehaviour
{
    [SerializeField] private GameObject gameoverTxt;

    private Rigidbody2D rb;

    private float jumpPower = 6f;
    private int jumpCnt = 1;
    public bool isGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (jumpCnt == 1)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isGround = false;
                jumpCnt = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            jumpCnt = 1;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            gameoverTxt.SetActive(true);
            Debug.Log(0);
        }
    }
}
