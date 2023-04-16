using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Enum;

public class WolfSpawn : MonoBehaviour
{
    public static WolfSpawn wolfSpawn;
    State state = State.idle;

    [SerializeField] private GameObject wolfSpawnPos;
    [SerializeField] private float wolfSpeed;
    [SerializeField] private float wolfCast;

    Rigidbody2D wolfRigidbody;

    private void Awake()
    {
        wolfSpawn = this;
        wolfRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() => WolfMove();

    public IEnumerator WolfStart()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        state = State.act;
    }

    private void WolfMove()
    {
        if (state == State.act)
        {
            wolfRigidbody.velocity = Vector2.right * wolfSpeed;

            RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.25f), Vector2.right, wolfCast);
            try
            {
                if (hit.collider.tag == "Sheep")
                    WolfAttack(hit.transform);
            }
            catch { }
        }
    }

    private void WolfAttack(Transform attackPos)
    {
        state = State.idle;
        transform.DOMoveX(attackPos.position.x, 0.3f).SetEase(Ease.Linear);
        GameOver.gameOver.HuntedOver();
    }

    public void WolfRun()
    {
        state = State.idle;
        float backPos = wolfSpawnPos.transform.position.x;
        transform.DOMoveX(backPos, 1f).SetEase(Ease.Linear);
    }
}