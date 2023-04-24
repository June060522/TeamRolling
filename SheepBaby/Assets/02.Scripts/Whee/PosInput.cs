using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using Enum;

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
    public State state = Enum.State.idle;
    private WolfSpawn wolfSpawn;

    [Header("Pos")]
    [SerializeField] private Transform orgPos;
    [SerializeField] private Transform housePos;

    [Header("Sheep")]
    [SerializeField] private float moveSpeed;

    private Boy boy;

    private void Awake()
        => wolfSpawn = FindObjectOfType<WolfSpawn>();

    private void Start()
    {
        input = this;
        boy = FindObjectOfType<Boy>();

        SheepMove[] sheeps = FindObjectsOfType<SheepMove>();
        foreach (SheepMove sheep in sheeps)
        {
            sheep.reStayTime = UnityEngine.Random.Range(sheep.stayTime - 2f, sheep.stayTime + 2f);

            Play[] plays = { Play.coloringtool, Play.ball, Play.snack, Play.puzzle, Play.consoleController};
            sheep.play = plays[UnityEngine.Random.Range(0, plays.Length)];
        }
    }

    public void GoPos(int number)
    {
        if (state == Enum.State.idle)
        {
            if (boy.isChose && !boy.isRest)
            {
                if (wolfSpawn.state == Enum.State.idle)
                {
                    Debug.Log("¾ÈµÅ µ¹¾Æ°¡2");
                    return;
                }
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
                        if ((posAction[number].act == Act.water && Food.Instance.moisture < 10) ||
                            (posAction[number].act == Act.eat && Food.Instance.food < 10))
                        {
                            Debug.Log("¾ÈµÅ µ¹¾Æ°¡");
                            return;
                        }
                        DOTween.KillAll();
                        Movement(posAction[number], sheep);
                        state = Enum.State.act;
                    }
                }
            }
        }
    }

    private void Movement(PosAction p, SheepMove sheep)
    {
        sheep.state = Enum.State.act;
        sheep.animator.SetBool("Move", true);

        float posRange = UnityEngine.Random.Range(p.pos.position.x - 1, p.pos.position.x + 1);
        sheep.SheepAnim(posRange);

        sheep.transform.DOMoveX(posRange, 1 / moveSpeed).SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            State(p.act, sheep);
        });
    }

    private void Movement(PosAction p)
    {
        boy.state = Enum.State.act;

        boy.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (p.act == Act.rest)
            boy.Rest();
        else
        {
            boy.transform.DOMoveX(p.pos.position.x, 1 / moveSpeed).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                State(p.act);
            });
        }
    }

    public void SheepBackOrg(SheepMove sheep)
    {
        float orgPosRange = UnityEngine.Random.Range(orgPos.position.x - 2.5f, orgPos.position.x + 2.5f);
        sheep.SheepAnim(orgPosRange);

        sheep.transform.DOMoveX(orgPosRange, 1 / moveSpeed).SetEase(Ease.Linear)
        .OnComplete(() => 
        { 
            state = Enum.State.idle; 
            sheep.animator.SetBool("Move", false);
        });
        sheep.RemoveEvent();
    }

    public void BoyBackOrg()
    {
        boy.transform.rotation = Quaternion.Euler(0, 180, 0);

        boy.transform.DOMoveX(housePos.position.x, 1 / moveSpeed).SetEase(Ease.Linear)
        .OnComplete(() => { state = Enum.State.idle; });

        boy.RemoveEvent();
    }

    void State(Act act, SheepMove sheep)
    {
        Action[] funtionEveny = { sheep.Water, sheep.Eat, sheep.Bell, sheep.Cut };
        funtionEveny[(int)act]();
    }

    void State(Act act)
    {
        Action[] funtionEveny = { boy.Water, boy.Eat, null, null, boy.Wolf, boy.Rest };
        funtionEveny[(int)act]();
    }
}
