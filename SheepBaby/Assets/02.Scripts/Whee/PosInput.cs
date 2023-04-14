using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;
using DG.Tweening;
using Enum;
using UnityEngine.Events;
using Unity.VisualScripting;

[System.Serializable]
public class PosAction
{
    public Transform pos;
    public Act act;
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
            if (sheep.isChose && sheep.state == SheepMove.State.idle)
            {
                SheepMovement(posAction[number], sheep);
            }
        }
    }

    private void SheepMovement(PosAction p, SheepMove sheep)
    {
        sheep.state = SheepMove.State.act;

        sheep.transform.DOMoveX(p.pos.position.x, 1 / moveSpeed)
        .OnComplete(() =>
        {
            SheepState(p.act, sheep);

            StartCoroutine(InvokeDelay(() =>
            {
                float orgPosRange = UnityEngine.Random.Range(orgPos.position.x - 2, orgPos.position.x + 2);
                sheep.transform.DOMoveX(orgPosRange, 1 / moveSpeed);
                sheep.RemoveEvent();
            }, actionTime));
        });
    }

    void SheepState(Act act, SheepMove sheep)
    {
        Action[] funtionEveny = { sheep.Water, sheep.Bell, sheep.Eat, sheep.Cut };
        funtionEveny[(int)act]();
    }

    IEnumerator InvokeDelay(Action act, float time)
    {
        yield return new WaitForSeconds(time);
        act?.Invoke();
    }
}
