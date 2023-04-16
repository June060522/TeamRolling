using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;
using UnityEditor.Tilemaps;
using UnityEditor.Build;
using DG.Tweening;

public class SheepMove : SheepAction
{
    private Boy boy;
    private GameObject icon;

    private SheepAbiliity sheepAbiliity;
    private MinigameManager minigameManager;

    [Header("Time")]
    float idleTime;
    public float stayTime;
    public float reStayTime;
    [SerializeField] private float moveTime;

    private void Awake()
    {
        icon = transform.GetChild(0).gameObject;
        boy = FindObjectOfType<Boy>();
        collider = this.GetComponent<BoxCollider2D>();

        sheepAbiliity = FindObjectOfType<SheepAbiliity>();
        minigameManager = FindObjectOfType<MinigameManager>();
    }

    private void Update()
    {
        idleTime += Time.deltaTime;

        if (state == State.idle) Idle();

        if (Input.GetMouseButtonDown(0) && state == State.idle) TouchThis();
        TouchState();
    }

    private void Idle()
    {
        if (idleTime > reStayTime + moveTime)
        {
            idleTime = 0;
            float movePos = Mathf.Clamp(UnityEngine.Random.Range(transform.position.x - 1f, transform.position.x + 1f), -2.5f, 1.5f);
            transform.DOMoveX(movePos, moveTime).SetEase(Ease.Linear);
        }
    }

    protected override void TouchThis()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
        
        if (hit.collider == collider)
        {
            base.TouchThis();
            boy.isChose = false;
        }
    }

    void TouchState()
    {
        icon.SetActive(isChose);
    }

    public override void Water()
    {
        if (Food.Instance.moisture >= 10)
        {
            Food.Instance.moisture -= 10;
            StartCoroutine(MiniGameDelay(minigameManager.WaterMinigame(sheepAbiliity)));
        }
        else
            PosInput.input.SheepBackOrg(this);
    }

    public override void Eat()
    {
        if (Food.Instance.food >= 10)
        {
            Food.Instance.food -= 10;
            StartCoroutine(MiniGameDelay(minigameManager.EatMinigame(sheepAbiliity)));
        }
        else
            PosInput.input.SheepBackOrg(this);
    }

    public override void Bell() 
        => StartCoroutine(MiniGameDelay(minigameManager.BellMinigame(sheepAbiliity)));

    public override void Cut() 
        => StartCoroutine(MiniGameDelay(minigameManager.CutMinigame()));

    IEnumerator MiniGameDelay(bool isClear)
    {
        while (!isClear)
            yield return new WaitForSeconds(1.0f);
        PosInput.input.SheepBackOrg(this);
    }
}
