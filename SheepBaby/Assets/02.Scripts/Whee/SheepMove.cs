using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : SheepAction
{
    public enum State { idle, water, bell, eat, cut};
    public State state = State.idle;

    [SerializeField] private GameObject icon;

    bool isChose;

    protected override void Awake()
    {
        
    }

    protected override void Update()
    {
        if (state == State.idle) Idle();

        if (Input.GetMouseButtonDown(0)) TouchSheep();
    }

    private void Idle()
    {
        Debug.Log("idle");
    }

    private void TouchSheep()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

        if (hit.transform.gameObject == gameObject)
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
        base.RemoveEvent();
    }
}
