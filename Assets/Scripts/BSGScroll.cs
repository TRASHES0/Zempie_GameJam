using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSGScroll : MonoBehaviour
{
    public MeshRenderer renderer;

    public float offset;
    public float speed;

    public int order;
    public string layerName;
    
    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.sortingLayerName = layerName;
        renderer.sortingOrder = order;
    }

    void Update()
    {
        if (renderer.sortingLayerName != layerName)
            renderer.sortingLayerName = layerName;
        if (renderer.sortingOrder != order)
            renderer.sortingOrder = order;

        offset += Time.deltaTime * speed;
        renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }

    public void OnValidate()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.sortingLayerName = layerName;
        renderer.sortingOrder = order;
    }
}
