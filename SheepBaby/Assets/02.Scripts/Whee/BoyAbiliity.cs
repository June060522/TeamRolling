using Enum;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class BoyAbiliity : MonoBehaviour
{
    [Header("소년 기본 스텟")]
    public float tired = 100f;

    private float lifeTime = 0f;

    private void Start()
    {
        StartCoroutine(BoyAbilityChange());
    }

    public void Update()
    {
        lifeTime += Time.deltaTime;

        BoyDie();
    }

    IEnumerator BoyAbilityChange()
    {
        float chandeValue;
        while (true)
        {
            chandeValue = lifeTime / 30 + 1;
            tired -= chandeValue;
            yield return new WaitForSeconds(3f);
        }
    }

    void BoyDie()
    {
        if (tired <= 0)
        {
            GameOver.gameOver.BurnOutOver(); 
        }
    }
}
