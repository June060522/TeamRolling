using Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyAbiliity : MonoBehaviour
{
    [Header("소년 기본 스텟")]
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
}
