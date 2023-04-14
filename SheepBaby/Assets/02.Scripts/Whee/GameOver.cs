using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private SheepAbiliity sheepAbiliity;

    private void Awake()
    {
        sheepAbiliity = GetComponent<SheepAbiliity>();
    }

    void Update()
    {
        StateOver();
    }

    void StateOver()
    {

    }
}
