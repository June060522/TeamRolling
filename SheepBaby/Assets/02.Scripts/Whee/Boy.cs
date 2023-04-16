using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class Boy : SheepAction
{
    BoyAbiliity boyAbiliity;

    [SerializeField] private float restTime;
    [SerializeField] private float restAmount;
    public bool isRest;

    void Awake()
    {
        collider = GameObject.FindWithTag("House").GetComponent<BoxCollider2D>();
        boyAbiliity = gameObject.GetComponent<BoyAbiliity>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && state == State.idle) TouchThis();
    }

    protected override void TouchThis()
    {
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

        if (hit.collider == collider)
        {
            base.TouchThis();
        }
    }

    public override void RemoveEvent()
    {
        base.RemoveEvent();
    }

    public override void Water()
    {
        Food.Instance.moisture = 100;
        PosInput.input.BoyBackOrg();
    }

    public override void Eat()
    {
        Food.Instance.food = 100;
        PosInput.input.BoyBackOrg();
    }

    public override void Wolf()
    {
        WolfSpawn.wolfSpawn.WolfRun();
        PosInput.input.BoyBackOrg();
    }

    public override void Rest()
    {
        isRest = true;
        StartCoroutine(Resting());
        PosInput.input.BoyBackOrg();
    }

    public IEnumerator Resting()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(restTime/10);
            boyAbiliity.tired += restAmount/10;
        }
        isRest = false;
    }
}
