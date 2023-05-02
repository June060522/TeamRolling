using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarSpawn : MonoBehaviour
{
    public Transform spawnTransform;
<<<<<<< Updated upstream
=======
    private new Renderer renderer;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
            spawnTransform.position = new Vector3(Random.Range(-7, 7), Random.Range(-4, 1.5f));
            Instantiate(Far, spawnTransform.position, spawnTransform.rotation);
=======
            spawnTransform.position = new Vector3(Random.Range(700f, 1250f), Random.Range(250f, 600f));
            GameObject obj = Instantiate(Far, spawnTransform.position, spawnTransform.rotation);
            obj.transform.parent = transform.parent;
            obj.transform.localScale = new Vector3(5, 5, 5);
>>>>>>> Stashed changes
        }
    }
}
