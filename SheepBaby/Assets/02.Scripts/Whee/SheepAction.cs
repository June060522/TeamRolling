using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Enum;

public class SheepAction : MonoBehaviour
{
    public State state = State.idle;

    protected new BoxCollider2D collider;

    public bool isChose;

    protected virtual void TouchThis()
    {
        SheepMove[] sheeps = FindObjectsOfType<SheepMove>();
        foreach (SheepMove sheep in sheeps)
            sheep.isChose = false;
        isChose = true;
    }

    public virtual void RemoveEvent()
    {
        state = State.idle;
        isChose = false;
    }

    public virtual void Water()
    {
        //bool gamePlay = ; bool형 미니게임 함수넣기, 미니게임 종료 후 꼭 false반환;
        while (!true)//gamePlay넣을 예정
        {
            //아무것도 안 넣을거임
        }
        Debug.Log("water");
    }

    public virtual void Eat()
    {
        Debug.Log("eat");
    }

    public virtual void Bell()
    {
        Debug.Log("bell");
    }

    public virtual void Cut()
    {
        Debug.Log("cut");
    }

    public virtual void Wolf()
    {
        //얜 미니게임 안함
        Debug.Log("bell");
    }

    public virtual void Rest()
    {
        Debug.Log("cut");
    }
}
