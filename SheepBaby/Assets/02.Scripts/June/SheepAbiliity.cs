using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SheepAbiliity : MonoBehaviour
{
    public enum Stat
    { fun, thirst, hungry, stress };

    [Header("¾ç ±âº» ½ºÅÝ")]
    //[SerializeField] float fun = 100f;
    [SerializeField] float thirst = 100f;
    [SerializeField] float hungry = 100f;
    [SerializeField] float stress = 100f;

    public float Thirst { get; private set; }
    public float Hungry { get; private set; }
    public float Stress { get; private set; }

    private float lifeTime = 0f;

    private void Start()
    {
        StartCoroutine(SheepAbilityChange());
        StateWindow();
    }

    public void Update()
    {
        lifeTime += Time.deltaTime;
    }

    private void StateWindow()
    {

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
                //fun += changeValue;
                break;
            case Stat.thirst:
                thirst += changeValue;
                break;
            case Stat.hungry:
                hungry += changeValue;
                break;
            case Stat.stress:
                stress += changeValue;
                break;
        }
    }
}
