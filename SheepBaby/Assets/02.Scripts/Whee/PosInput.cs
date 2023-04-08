using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;
using DG.Tweening;

public class PosInput : MonoBehaviour, IPosEvent
{
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
    protected List<GameObject> sheeps;

    protected virtual void Awake()
    {
        
    }

    protected virtual void Update()
    {

    }

    private void GoPos(Transform pos ,Action even)
    {
        foreach (GameObject sheep in sheeps)
        {
            sheep.transform.DOMove(pos.position, moveSpeed)
            .OnComplete(() => { even?.Invoke(); });
        }
    }

    public void WaterAction() => GoPos(waterPos, OnWaterEvent);

    public void BellAction() => GoPos(bellPos, OnBellEvent);

    public void EatAction() => GoPos(eatPos, OnEatEvent);

    public void CutAction() => GoPos(cutPos, OnCutingEvent);

    public virtual void AddEvent() { }

    public virtual void RemoveEvent() 
    {
        foreach(GameObject sheep in sheeps)
            sheep.transform.DOMove(orgPos.position, moveSpeed);
    }
}
