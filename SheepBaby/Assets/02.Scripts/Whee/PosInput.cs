using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;
using DG.Tweening;
using Enum;
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
    public Enum.State state = Enum.State.idle;

    [Header("Pos")]
    [SerializeField] private Transform orgPos;

    [Header("Sheep")]
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        input = this;
    }

    public void GoPos(int number)
    {
        if (state == Enum.State.idle)
        {
            SheepMove[] sheeps = FindObjectsOfType<SheepMove>();
            foreach (SheepMove sheep in sheeps)
            {
                if (sheep.isChose)
                {
                    SheepMovement(posAction[number], sheep);
                }
            }
            state = Enum.State.act;
        }
    }

    private void SheepMovement(PosAction p, SheepMove sheep)
    {
        sheep.state = Enum.State.act;

        float posRange = UnityEngine.Random.Range(p.pos.position.x - 1, p.pos.position.x + 1);

        sheep.transform.DOMoveX(posRange, 1 / moveSpeed).SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            SheepState(p.act, sheep);
        });
    }

    public void SheepBackOrg(SheepMove sheep)
    {
        state = Enum.State.idle;

        float orgPosRange = UnityEngine.Random.Range(orgPos.position.x - 2.5f, orgPos.position.x + 2.5f);
        sheep.transform.DOMoveX(orgPosRange, 1 / moveSpeed).SetEase(Ease.Linear);
        sheep.RemoveEvent();
    }

    void SheepState(Act act, SheepMove sheep)
    {
        Action[] funtionEveny = { sheep.Water, sheep.Eat };
        funtionEveny[(int)act]();
    }
}
