using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;
using UnityEditor.Tilemaps;
using UnityEditor.Build;

public class SheepMove : SheepAction
{
    private Boy boy;
    private GameObject icon;

    public Action sheepIdle;

    private void Awake()
    {
        icon = transform.GetChild(0).gameObject;
        boy = FindObjectOfType<Boy>();
        collider = this.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (state == State.idle) Idle();

        if (Input.GetMouseButtonDown(0) && state == State.idle) TouchThis();
        TouchState();
    }

    private void Idle()
    {
        
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

    //�� true�ȿ��ٰ� bool�� �̴ϰ��� �Լ��ֱ�(�������϶� false, �� ������ true)
    public override void Water() => StartCoroutine(MiniGameDelay(true));

    public override void Eat() => StartCoroutine(MiniGameDelay(true));

    public override void Bell() => StartCoroutine(MiniGameDelay(true));

    public override void Cut() => StartCoroutine(MiniGameDelay(true));

    IEnumerator MiniGameDelay(bool isClear)
    {
        while (!isClear)
            yield return new WaitForSeconds(1.0f);
        PosInput.input.SheepBackOrg(this);
    }
}
