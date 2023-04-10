using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;
using DG.Tweening;
using Enum;
using UnityEngine.Events;

[System.Serializable]
public class PosAction
{
    public Transform pos;
    public SheepMove.State state;
}

public class PosInput : MonoBehaviour
{
    public static PosInput input;
    public PosAction[] posAction = new PosAction[0];

    [Header("Pos")]
    [SerializeField] private Transform orgPos;

    [Header("Sheep")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float actionTime;

    private void Awake()
    {
        input = this;
    }

    public void GoPos(int number)
    {
        SheepMove[] sheeps = FindObjectsOfType<SheepMove>();
        foreach (SheepMove sheep in sheeps)
        {
            if (sheep.isChose)
            {
                SheepMovement(posAction[number].pos, sheep);
                SheepState(posAction[number].state, sheep);
            }
        }
    }

    void SheepState(SheepMove.State state, SheepMove sheep)
    {
        sheep.state = state;
        sheep.Water();
    }

    private void SheepMovement(Transform pos, SheepMove sheep)
    {
        sheep.transform.DOMove(pos.position, 1 / moveSpeed)
        .OnComplete(() =>
        {
            StartCoroutine(InvokeDelay(() =>
            {
                sheep.transform.DOMove(orgPos.position, 1 / moveSpeed);
            }, actionTime));
        });
    }

    IEnumerator InvokeDelay(Action act, float time)
    {
        yield return new WaitForSeconds(time);
        act?.Invoke();
    }
}
