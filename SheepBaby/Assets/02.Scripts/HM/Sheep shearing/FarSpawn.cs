using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarSpawn : MonoBehaviour
{
    public Transform spawnTransform;

    public GameObject Far;
    public Scissor scissor;

    public void Start()
    {
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        for(int i = 0; i < 15; i++)
        {
            spawnTransform.position = new Vector3(Random.Range(-7, 7), Random.Range(-4, 1.5f));
            Instantiate(Far, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
