using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;
using DG.Tweening;
using Enum;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEditor;

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
    [SerializeField] private Transform housePos;

    [Header("Sheep")]
    [SerializeField] private float moveSpeed;

    private Boy boy;

    private void Awake()
    {
        input = this;
        boy = GetComponent<Boy>();
    }

    public void GoPos(int number)
    {
        if (state == Enum.State.idle)
        {
            if (boy.isChose)
            {
                Movement(posAction[number]);
                state = Enum.State.act;
            }
            else
            {
                SheepMove[] sheeps = FindObjectsOfType<SheepMove>();
                foreach (SheepMove sheep in sheeps)
                {
                    if (sheep.isChose)
                    {
                        Movement(posAction[number], sheep);
                    }
                }
                state = Enum.State.act;
            }
        }
    }

    private void Movement(PosAction p, SheepMove sheep)
    {
        sheep.state = Enum.State.act;

        float posRange = UnityEngine.Random.Range(p.pos.position.x - 1, p.pos.position.x + 1);

        sheep.transform.DOMoveX(posRange, 1 / moveSpeed).SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            State(p.act, sheep);
        });
    }

    private void Movement(PosAction p)
    {
        boy.state = Enum.State.act;

        boy.transform.DOMoveX(p.pos.position.x, 1 / moveSpeed).SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            State(p.act);
        });
    }

    public void SheepBackOrg(SheepMove sheep)
    {
        state = Enum.State.idle;

        float orgPosRange = UnityEngine.Random.Range(orgPos.position.x - 2.5f, orgPos.position.x + 2.5f);
        sheep.transform.DOMoveX(orgPosRange, 1 / moveSpeed).SetEase(Ease.Linear);
        sheep.RemoveEvent();
    }

    public void BoyBackOrg()
    {
        state = Enum.State.idle;

        boy.transform.DOMoveX(housePos.position.x, 1 / moveSpeed).SetEase(Ease.Linear);
        boy.RemoveEvent();
    }

    void State(Act act, SheepMove sheep)
    {
        Action[] funtionEveny = { sheep.Water, sheep.Eat, sheep.Bell, sheep.Cut };
        funtionEveny[(int)act]();
    }

    void State(Act act)
    {
        Action[] funtionEveny = { boy.Water, boy.Eat, boy.Wolf, boy.Rest };
        funtionEveny[(int)act]();
    }
}
