using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAction : MonoBehaviour
{
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
