using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    private Transform _tp;
    private float offset;

    public float speed = 0.5f;


    void Start()
    {
        TryGetComponent(out _tp);
    }

    // Update is called once per frame
    void Update()
    {
        offset -= Time.deltaTime * speed;
        _tp.position = new Vector2(offset, _tp.position.y);
    }
}
