using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class SheepMove : SheepAction
{
    public State state = State.idle;

    private GameObject icon;
    private new BoxCollider2D collider;

    public bool isChose;

    private void Awake()
    {
        icon = transform.GetChild(0).gameObject;
        collider = this.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (state == State.idle) Idle();

        if (Input.GetMouseButtonDown(0) && state == State.idle) TouchSheep();
    }

    private void Idle()
    {
        
    }

    private void TouchSheep()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

        if (hit.collider == collider)
        {
            isChose = !isChose;
            icon.SetActive(isChose);
        }
    }

    public void RemoveEvent()
    {
        state = State.idle;
        isChose = false;
        icon.SetActive(false);
    }

    public override void Water()
    {
        base.Water();
        PosInput.input.SheepBackOrg(this);
    }

    public override void Eat()
    {
        base.Eat();
        PosInput.input.SheepBackOrg(this);
    }

    //public override void Bell()
    //{
    //    base.Bell();
    //    PosInput.input.SheepBackOrg(this);
    //}

    //public override void Cut()
    //{
    //    base.Cut();
    //    PosInput.input.SheepBackOrg(this);
    //}
}
