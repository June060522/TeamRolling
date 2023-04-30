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
    public Play play;

    private Boy boy;
    private GameObject icon;

    private SheepAbiliity sheepAbiliity;
    private MinigameManager minigameManager;
    private MinigameStore minigameStore;
    public Animator animator;

    [Header("Time")]
    float idleTime;
    public float stayTime;
    [HideInInspector] public float reStayTime;
    [SerializeField] private float moveTime;

    private void Awake()
    {
        boy = FindObjectOfType<Boy>();
        collider = this.GetComponent<CapsuleCollider2D>();

        sheepAbiliity = FindObjectOfType<SheepAbiliity>();
        minigameManager = FindObjectOfType<MinigameManager>();
        minigameStore = FindObjectOfType<MinigameStore>();
        animator = gameObject.GetComponent<Animator>();
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
            animator.SetBool("Move", true);

            idleTime = 0;
            float movePos = Mathf.Clamp(UnityEngine.Random.Range(transform.position.x - 1f, 
                transform.position.x + 1f), -6f, 5.5f);
            SheepAnim(movePos);

            transform.DOMoveX(movePos, moveTime).SetEase(Ease.Linear)
                .OnComplete(() => { animator.SetBool("Move", false); });
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
        
    }

    public void SheepAnim(float pos)
    {
        if (pos > transform.position.x) transform.rotation = Quaternion.Euler(0, 180, 0);
        else transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private bool PossibleGame()
    {
        foreach (string key in minigameStore.keys)
        {
            if (play.ToString() == key)
                return true;
        }
        return false;
    }

    public override void Water()
    {
        Food.Instance.moisture -= 10;
        StartCoroutine(minigameManager.WaterMinigames(this, sheepAbiliity));
    }

    public override void Eat()
    {
        Food.Instance.food -= 10;
        StartCoroutine(minigameManager.EatMinigame(this, sheepAbiliity));
    }

    public override void Bell()
    {
        if (PossibleGame())
        {
            StartCoroutine(minigameManager.BellMinigame(this, sheepAbiliity, play));
        }
        else
            PosInput.input.SheepBackOrg(this);
    }

    public override void Cut() 
        => StartCoroutine(minigameManager.CutMinigame(this, sheepAbiliity));

    IEnumerator MiniGameDelay(bool isClear)
    {
        while (!isClear)
        {
            Debug.Log(90);
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log(180);
        PosInput.input.SheepBackOrg(this);
    }
}
