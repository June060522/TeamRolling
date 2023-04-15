using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class Boy : SheepAction
{
    void Awake()
    {
        collider = GameObject.FindWithTag("House").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    protected override void TouchThis()
    {
        base.TouchThis();
    }

    public override void RemoveEvent()
    {
        base.RemoveEvent();
    }

    public override void Water()
    {
        base.Water();
    }

    public override void Eat()
    {
        base.Eat();
        PosInput.input.BoyBackOrg();
    }

    public override void Wolf()
    {
        base.Wolf();
        PosInput.input.BoyBackOrg();
    }

    public override void Rest()
    {
        base.Rest();
        PosInput.input.BoyBackOrg();
    }
}
