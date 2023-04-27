using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleMinigame : MonoBehaviour
{
    [SerializeField] Image[] levelOne;// 2 * 2
    [SerializeField] Image[] levelTwo;// 3 * 3

    private void Start()
    {
        Setting(2); 
    }
    private void Setting(int level)
    {
        if (level == 1)
            LevelOne();
        else if (level == 2)
            LevelTwo();
    }

    private void LevelOne()
    {
        for(int i = 0; i < levelOne.Length; i++)
        {
            Image img = Instantiate(levelOne[i],this.transform);
            img.transform.localPosition = 
                new Vector2(Random.Range(-900f, 900f), Random.Range(-500f, 500f));
        }
    }
    private void LevelTwo()
    {
        for (int i = 0; i < levelTwo.Length; i++)
        {
            Image img = Instantiate(levelTwo[i], this.transform);
            img.transform.localPosition =
                new Vector2(Random.Range(-900f, 900f), Random.Range(-500f, 500f));
        }
    }
}