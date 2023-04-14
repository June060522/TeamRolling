using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAction : MonoBehaviour
{
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

    //public virtual void Bell()
    //{
    //    Debug.Log("bell");
    //}

    //public virtual void Cut()
    //{
    //    Debug.Log("cut");
    //}

    public virtual void Wolf()
    {
        Debug.Log("bell");
    }

    public virtual void Rest()
    {
        Debug.Log("cut");
    }
}
