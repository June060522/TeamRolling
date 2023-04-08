using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : SheepAction
{
    public enum State { idle, water, bell, eat, cut};
    public State state = State.idle;

    private GameObject icon;
    private new BoxCollider2D collider;

    bool isChose;

    protected override void Awake()
    {
        icon = transform.GetChild(0).gameObject;
        collider = this.GetComponent<BoxCollider2D>();
    }

    protected override void Update()
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

            if (isChose) sheeps.Add(this);
            else sheeps.Remove(this);
        }
    }

    public override void AddEvent()
    {
        switch (state)
        {
            case State.water:
                Debug.Log("df");
                input.OnWaterEvent += Water;
                break;
            case State.bell:
                input.OnWaterEvent += Bell;
                break;
            case State.eat:
                input.OnWaterEvent += Eat;
                break;
            case State.cut:
                input.OnWaterEvent += Cut;
                break;
        }
    }

    public override void RemoveEvent()
    {
        switch (state)
        {
            case State.water:
                input.OnWaterEvent -= Water;
                break;
            case State.bell:
                input.OnWaterEvent -= Bell;
                break;
            case State.eat:
                input.OnWaterEvent -= Eat;
                break;
            case State.cut:
                input.OnWaterEvent -= Cut;
                break;
        }

        isChose = false;
        icon.SetActive(isChose);
        sheeps.Remove(this);

        base.RemoveEvent();
    }
}
