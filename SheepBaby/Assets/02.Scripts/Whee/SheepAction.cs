using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Enum;

public class SheepAction : MonoBehaviour
{
    public State state = State.idle;

    protected new CapsuleCollider2D collider;

    public bool isChose;

    protected virtual void TouchThis()
    {
        MinigameSheepMove[] sheeps = FindObjectsOfType<MinigameSheepMove>();
        foreach (MinigameSheepMove sheep in sheeps)
            sheep.isChose = false;
        isChose = true;
    }

    public virtual void RemoveEvent()
    {
        state = State.idle;
        isChose = false;
    }

    public virtual void Water() { }
    public virtual void Eat() { }
    public virtual void Bell() { }
    public virtual void Cut() { }
    public virtual void Wolf() { }
    public virtual void Rest() { }
}
