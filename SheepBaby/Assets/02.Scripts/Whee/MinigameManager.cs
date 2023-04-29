using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;
using DG.Tweening;

public class MinigameManager : MonoBehaviour
{
    BoyAbiliity boyAbiliity;

    [SerializeField] private GameObject picturePanel;
    [SerializeField] private GameObject waterPanel;

    private void Awake()
    {
        boyAbiliity = FindObjectOfType<BoyAbiliity>();

        //pictureMinigame.enabled = false;
    }

    public IEnumerator WaterMinigames(SheepMove sheep, SheepAbiliity sheepAbiliity)
    {
        TimeCount.Instance.enabled = false;
        bool end = false;
        while (!end)
        {
            float plusValue = 0;

            waterPanel.SetActive(true);

            if (WaterMinigame.instance.EndGame(out plusValue))//���ǹ��� bool���� �̴ϰ��� ������ �Լ� �ֱ�(out float �ްԺ��� �־� plusValue�ٲ��ְ�)
            {
                sheepAbiliity.ChangeStat(Stat.thirst, plusValue);
                waterPanel.SetActive(false);
                end = true;
            }
            yield return new WaitForSeconds(0.2f);
        }
        TimeCount.Instance.enabled = true;
        PosInput.input.SheepBackOrg(sheep);
    }

    public IEnumerator EatMinigame(SheepMove sheep, SheepAbiliity sheepAbiliity)
    {
        TimeCount.Instance.enabled = false;
        bool end = false;
        while (!end)
        {
            float plusValue = 0;

            if (true)//���ǹ��� bool���� �̴ϰ��� ������ �Լ� �ֱ�(out float �ްԺ��� �־� plusValue�ٲ��ְ�)
            {
                sheepAbiliity.ChangeStat(Stat.hungry, plusValue);
                end = true;
            }
            yield return new WaitForSeconds(0.2f);
        }
        TimeCount.Instance.enabled = true;
        PosInput.input.SheepBackOrg(sheep);
    }

    public IEnumerator BellMinigame(SheepMove sheep, SheepAbiliity sheepAbiliity, Play play)
    {
        TimeCount.Instance.enabled = false;
        bool end = false;
        while (!end)
        {
            switch (play)
            {
                case Play.coloringtool:
                    end = true;
                    break;
                case Play.ball:
                    end = true;
                    break;
                case Play.snack:
                    end = true;
                    break;
                case Play.puzzle:
                    end = Puzzle(sheepAbiliity);
                    break;
                case Play.consoleController:
                    end = true;
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
        TimeCount.Instance.enabled = true;
        PosInput.input.SheepBackOrg(sheep);
    }

    public IEnumerator CutMinigame(SheepMove sheep, SheepAbiliity sheepAbiliity)
    {
        TimeCount.Instance.enabled = false;
        bool end = false;
        while (!end)
        {
            if (true)//���ǹ��� bool���� �̴ϰ��� ������ �Լ� �ֱ�(out float �ްԺ��� �־� plusValue�ٲ��ְ�)
            {
                boyAbiliity.paper++;
                end = true;
            }
            yield return new WaitForSeconds(0.2f);
        }
        TimeCount.Instance.enabled = true;
        PosInput.input.SheepBackOrg(sheep);
    }

    bool Puzzle(SheepAbiliity sheepAbiliity)
    {
        float plusValue = 0;

        picturePanel.SetActive(true);

        if (PictureMinigame.instance.EndGame(out plusValue))
        {
            sheepAbiliity.ChangeStat(Stat.stress, plusValue);

            picturePanel.SetActive(false);

            return true;
        }
        else
            return false;
    }
}
