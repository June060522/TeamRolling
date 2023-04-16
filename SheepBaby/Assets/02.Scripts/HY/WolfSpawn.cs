using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawn : MonoBehaviour
{
    private TimeCount timeCount;
    private int randomSpawn;

    void Start()
    {
        timeCount = FindObjectOfType<TimeCount>();
        WolfRandomSpawn();
    }

    void Update()
    {

    }

    IEnumerator WolfRandomSpawn()
    {
        if (timeCount.isNight == true)
            randomSpawn = Random.Range(0, 10);
        else if (timeCount.isNight == false)
            randomSpawn = 0;
        Debug.Log(randomSpawn);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(WolfRandomSpawn());
    }
}