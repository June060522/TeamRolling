using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class MinigameManager : MonoBehaviour
{
    BoyAbiliity boyAbiliity;

    PictureMinigame pictureMinigame;

    private void Awake()
    {
        boyAbiliity = FindObjectOfType<BoyAbiliity>();
        pictureMinigame = FindObjectOfType<PictureMinigame>();

        pictureMinigame.enabled = false;
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

    public bool BellMinigame(SheepAbiliity sheepAbiliity, Play play)
    {
        //�̴ϰ��� ����(return false�� �� ������)
        switch (play)
        {
            case Play.coloringtool:
                return true;
            case Play.ball:
                return true;
            case Play.snack:
                return true;
            case Play.puzzle:
                return Puzzle(sheepAbiliity);
            case Play.consoleController:
                return true;
        }
        return true;
    }

    public bool CutMinigame()
    {
        int plusValue = 0;

        //�̴ϰ��� ����(return false�� �� ������)

        //�̴ϰ��� �� �ϸ�...
        boyAbiliity.paper += plusValue;
        return true;
    }

    bool Puzzle(SheepAbiliity sheepAbiliity)
    {
        float plusValue = 0;

        pictureMinigame.enabled = true;
        if (pictureMinigame.EndGame(out plusValue))
        {
            sheepAbiliity.ChangeStat(Stat.stress, plusValue);
            pictureMinigame.enabled = false;
            return true;
        }
        else
            return false;
    }
}
