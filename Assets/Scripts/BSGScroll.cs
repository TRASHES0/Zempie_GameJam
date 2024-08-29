using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSGScroll : MonoBehaviour
{
    public MeshRenderer renderer;

    public float offset;
    public float speed;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }

}
