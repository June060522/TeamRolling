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
        //bool gamePlay = ; bool�� �̴ϰ��� �Լ��ֱ�, �̴ϰ��� ���� �� �� false��ȯ;
        while (!true)//gamePlay���� ����
        {
            //�ƹ��͵� �� ��������
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
        //�� �̴ϰ��� ����
        Debug.Log("bell");
    }

    public virtual void Rest()
    {
        Debug.Log("cut");
    }
}
