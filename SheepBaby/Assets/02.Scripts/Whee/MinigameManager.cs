using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class MinigameManager : MonoBehaviour
{
    BoyAbiliity boyAbiliity;

    private void Awake()
    {
        boyAbiliity = FindObjectOfType<BoyAbiliity>();
    }

    public bool WaterMinigame(SheepAbiliity sheepAbiliity)
    {
        float plusValue = 0;

        //�̴ϰ��� ����(return false�� �� ������)

        //�̴ϰ��� �� �ϸ�...
        sheepAbiliity.ChangeStat(Stat.thirst, plusValue);
        return true;
    }

    public bool EatMinigame(SheepAbiliity sheepAbiliity)
    {
        float plusValue = 0;

        //�̴ϰ��� ����(return false�� �� ������)

        //�̴ϰ��� �� �ϸ�...
        sheepAbiliity.ChangeStat(Stat.hungry, plusValue);
        return true;
    }

    public bool BellMinigame(SheepAbiliity sheepAbiliity)
    {
        float plusValue = 0;

        //�̴ϰ��� ����(return false�� �� ������)

        //�̴ϰ��� �� �ϸ�...
        sheepAbiliity.ChangeStat(Stat.stress, plusValue);
        return true;
    }

    public bool CutMinigame()
    {
        float plusValue = 0;

        //�̴ϰ��� ����(return false�� �� ������)

        //�̴ϰ��� �� �ϸ�...
        boyAbiliity.tired += plusValue;
        return true;
    }
}
