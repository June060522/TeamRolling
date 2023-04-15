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
        base.TouchThis();
        boy.isChose = false;
    }

    void TouchState()
    {
        icon.SetActive(isChose);
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

    public override void Bell()
    {
        base.Bell();
        PosInput.input.SheepBackOrg(this);
    }

    public override void Cut()
    {
        base.Cut();
        PosInput.input.SheepBackOrg(this);
    }
}
