using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : MonoBehaviour
{
    public enum State { idle, water, bell, eat, cut};
    public State state = State.idle;

    public GameObject icon;
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

    public void AddEvent()
    {
        switch (state)
        {
            case State.water:
                Water();
                break;
            case State.bell:
                Bell();
                break;
            case State.eat:
                Eat();
                break;
            case State.cut:
                Cut();
                break;
        }
    }

    public void RemoveEvent()
    {
        state = State.idle;
        isChose = false;
        icon.SetActive(false);
    }

    public void Water()
    {
        Debug.Log("water");
    }

    public void Bell()
    {
        Debug.Log("bell");
    }

    public void Eat()
    {
        Debug.Log("eat");
    }

    public void Cut()
    {
        Debug.Log("cut");
    }
}
