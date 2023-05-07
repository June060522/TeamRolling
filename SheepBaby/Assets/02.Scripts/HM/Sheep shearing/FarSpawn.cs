using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarSpawn : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private GameObject Far;

    public void OnEnable()
    {
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        for(int i = 0; i < 15; i++)
        {
            spawnTransform.position = new Vector3(Random.Range(700f, 1250f), Random.Range(250f, 600f));
            GameObject obj = Instantiate(Far, spawnTransform.position, spawnTransform.rotation);
            obj.transform.parent = parentObject.transform;
            obj.transform.localScale = new Vector3(5, 5, 5);
        }
    }
}
