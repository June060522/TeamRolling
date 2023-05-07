using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private float speed=0.4f;
    private float offset;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        meshRenderer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
