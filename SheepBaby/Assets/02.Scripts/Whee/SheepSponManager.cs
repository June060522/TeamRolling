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
        float pos = -((PlayerPrefs.GetFloat("SheepAmount") - 1) / 2);
        for (float i = pos; i <= -pos; i += 1f)
        {
            GameObject newSheep = Instantiate(sheep, new Vector3(i, -0.02f, 0), Quaternion.identity);
            newSheep.transform.parent = sheepEmple.transform;
        }
    }
}
