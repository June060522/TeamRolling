using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Enum;

public class SheepAbiliity : MonoBehaviour
{
    [Header("¾ç ±âº» ½ºÅÝ")]
    [SerializeField] public float fun = 100f;
    [SerializeField] public float thirst = 100f;
    [SerializeField] public float hungry = 100f;
    //[SerializeField] float stress = 100f;

    public float Thirst { get { return thirst; } private set { } }
    public float Hungry { get { return hungry; } private set { } }
    public float Fun { get { return fun; } private set { } }

    private float lifeTime = 0f;

    private void Start()
    {
        StartCoroutine(SheepAbilityChange());
    }

    public void Update()
    {
        lifeTime += Time.deltaTime;

        SheepDie();
    }

    IEnumerator SheepAbilityChange()
    {
        float chandeValue;
        while (true)
        {
            chandeValue = lifeTime / 30 + 1;
            ChangeStat(Stat.fun, -chandeValue);
            ChangeStat(Stat.thirst, -chandeValue);
            ChangeStat(Stat.hungry, -chandeValue);
            ChangeStat(Stat.stress, -chandeValue);
            yield return new WaitForSeconds(3f);
        }
    }

    public void ChangeStat(Stat stat, float changeValue)
    {
        switch (stat)
        {
            case Stat.fun:
                fun += changeValue;
                break;
            case Stat.thirst:
                thirst += changeValue;
                break;
            case Stat.hungry:
                hungry += changeValue;
                break;
            case Stat.stress:
                //stress += changeValue;
                break;
        }
    }

    void SheepDie()
    {
        if (thirst <= 0 || hungry <= 0 || fun <= 0)
        {
            GameOver.gameOver.StateOver();
        }
    }
}
