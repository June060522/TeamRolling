using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Enum;

public class WolfSpawn : MonoBehaviour
{
    public static WolfSpawn wolfSpawn;
    public State state = State.idle;

    private Animator animator;

    [SerializeField] private GameObject wolfSpawnPos;
    [SerializeField] private float wolfSpeed;
    [SerializeField] private float wolfCast;

    Rigidbody2D wolfRigidbody;

    private void Awake()
    {
        wolfSpawn = this;
        wolfRigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
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

            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("Action", true);

            RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.0f), Vector2.right, wolfCast);
            try
            {
                if (hit.collider.tag == "Sheep")
                    WolfAttack(hit.transform);
            }
            catch { }
        }
        else
        {
            wolfRigidbody.velocity = Vector2.zero;
            animator.SetBool("Action", false);
        }
    }

    private void WolfAttack(Transform attackPos)
    {
        state = State.idle;

        animator.SetTrigger("Attack");

        transform.DOMoveX(attackPos.position.x, 0.5f).SetEase(Ease.Linear)
        .OnComplete(() => { GameOver.gameOver.HuntedOver(); });
    }

    public void WolfRun()
    {
        state = State.idle;

        transform.rotation = Quaternion.Euler(0, 0, 0);

        float backPos = wolfSpawnPos.transform.position.x;
        transform.DOMoveX(backPos, 1f).SetEase(Ease.Linear);
    }
}