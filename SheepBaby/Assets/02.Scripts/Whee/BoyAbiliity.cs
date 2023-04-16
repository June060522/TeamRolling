using Enum;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class BoyAbiliity : MonoBehaviour
{
    [Header("�ҳ� �⺻ ����")]
    [SerializeField] float tired = 100f;

    public float Tired { get { return tired; } private set { } }

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
