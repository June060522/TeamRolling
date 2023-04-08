using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;
using DG.Tweening;

public class PosInput : MonoBehaviour, IPosEvent
{
    static protected PosInput input;

    [Header("Pos")]
    [SerializeField] private Transform waterPos;
    [SerializeField] private Transform bellPos;
    [SerializeField] private Transform eatPos;
    [SerializeField] private Transform cutPos;
    [SerializeField] private Transform orgPos;

    [Header("Sheep")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float actionTime;

    static protected List<SheepMove> sheeps = new List<SheepMove>();

    protected virtual void Awake()
    {
        input = this;
    }

    protected virtual void Update()
    {

    }

    private void GoPos(Transform pos, SheepMove.State _state)
    {
        foreach (SheepMove sheep in sheeps)
        {
            if (sheep.state == SheepMove.State.idle)
            {
                sheep.state = _state;
                sheep.AddEvent();

                sheep.transform.DOMove(pos.position, 1 / moveSpeed)
                .OnComplete(() =>
                {
                    StartCoroutine(InvokeDelay(() => 
                    { 
                        sheep.RemoveEvent(sheep);
                        RemoveEvent(sheep);
                    }, actionTime));
                });
            }
        }
    }

    public void WaterAction() => GoPos(waterPos, SheepMove.State.water);

    public void BellAction() => GoPos(bellPos, SheepMove.State.bell);

    public void EatAction() => GoPos(eatPos, SheepMove.State.eat);

    public void CutAction() => GoPos(cutPos, SheepMove.State.cut);

    public virtual void AddEvent() { }

    public virtual void RemoveEvent(SheepMove sheep)
    {
        sheep.transform.DOMove(orgPos.position, 1 / moveSpeed);
    }

    IEnumerator InvokeDelay(Action act, float time)
    {
        yield return new WaitForSeconds(time);
        act?.Invoke();
    }
}
