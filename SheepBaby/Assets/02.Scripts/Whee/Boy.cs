using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

public class Boy : SheepAction
{
    [SerializeField] private float restTime;
    bool isRest;

    void Awake()
    {
        collider = GameObject.FindWithTag("House").GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && state == State.idle) TouchThis();
    }

    protected override void TouchThis()
    {
        if (!isRest)
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            if (hit.collider == collider)
            {
                base.TouchThis();
            }
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
        //´Á´ë ÂÑ¾Æ³»±â
        base.Wolf();
        PosInput.input.BoyBackOrg();
    }

    public override void Rest()
    {
        isRest = true;
        StartCoroutine(Resting());
    }

    public IEnumerator Resting()
    {
        yield return new WaitForSeconds(restTime);
        isRest = false;
    }
}
