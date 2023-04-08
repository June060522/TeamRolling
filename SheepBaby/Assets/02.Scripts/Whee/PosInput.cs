using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;
using DG.Tweening;

public class PosInput : MonoBehaviour, IPosEvent
{
    protected PosInput input;

    public event Action OnWaterEvent;
    public event Action OnBellEvent;
    public event Action OnEatEvent;
    public event Action OnCutingEvent;

    [Header("Pos")]
    [SerializeField] private Transform waterPos;
    [SerializeField] private Transform bellPos;
    [SerializeField] private Transform eatPos;
    [SerializeField] private Transform cutPos;
    [SerializeField] private Transform orgPos;

    [Header("Sheep")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float actionTime;
    protected List<SheepMove> sheeps;

    protected virtual void Awake()
    {
        input = this;
    }

    protected virtual void Update()
    {

    }

    private void GoPos(Transform pos, Action even, SheepMove.State _state)
    {
        foreach (SheepMove sheep in sheeps)
        {
            sheep.state = _state;
            sheep.transform.DOMove(pos.position, moveSpeed)
            .OnComplete(() =>
            {
                AddEvent();
                even?.Invoke();
                Invoke("RemoveEvent", actionTime);
            });
        }
    }

    public void WaterAction() => GoPos(waterPos, OnWaterEvent, SheepMove.State.water);

    public void BellAction() => GoPos(bellPos, OnBellEvent, SheepMove.State.bell);

    public void EatAction() => GoPos(eatPos, OnEatEvent, SheepMove.State.eat);

    public void CutAction() => GoPos(cutPos, OnCutingEvent, SheepMove.State.cut);

    public virtual void AddEvent() { }

    public virtual void RemoveEvent() 
    {
        foreach (SheepMove sheep in sheeps)
        {
            sheep.transform.DOMove(orgPos.position, moveSpeed);
            sheep.state = SheepMove.State.idle;
        }
    }
}
