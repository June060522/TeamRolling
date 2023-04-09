using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;
using DG.Tweening;
using Enum;

public class PosInput : MonoBehaviour
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

    private void Awake()
    {
        input = this;
    }

    public void GoPos(Transform pos)
    {
        SheepMove[] sheeps = FindObjectsOfType<SheepMove>();
        foreach (SheepMove sheep in sheeps)
        {
            if (sheep.isChose)
            {
                SheepMovement(pos, sheep);
            }
        }
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
