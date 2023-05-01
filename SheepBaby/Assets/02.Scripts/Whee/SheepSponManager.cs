using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SheepSponManager : MonoBehaviour
{
    [SerializeField] GameObject sheep;
    [SerializeField] GameObject sheepEmple;

    private void Awake()
    {
        GameObject[] sheeps = GameObject.FindGameObjectsWithTag("Sheep");
        foreach (GameObject oneSheep in sheeps)
        {
            oneSheep.GetComponent<SheepMove>().enabled = true;
            oneSheep.GetComponent<SheepAbiliity>().enabled = true;
        }
    }
}
