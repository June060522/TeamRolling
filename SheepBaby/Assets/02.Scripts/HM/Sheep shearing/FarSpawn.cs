using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarSpawn : MonoBehaviour
{
    public Transform spawnTransform;
    private Renderer renderer;

    public GameObject Far;
    //public Scissor scissor;

    public void Start()
    {
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        for(int i = 0; i < 15; i++)
        {
            spawnTransform.position = new Vector3(Random.Range(-1f, 4f), Random.Range(-3.7f, 1.3f));
            GameObject obj = Instantiate(Far, spawnTransform.position, spawnTransform.rotation);
            obj.GetComponent<Renderer>().sortingOrder = i;
        }
    }
}
