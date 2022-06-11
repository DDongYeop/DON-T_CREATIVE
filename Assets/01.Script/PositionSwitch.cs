using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSwitch : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _scrollSize = 10.8f;
    void Update()
    {
        if (transform.position.y <= -_scrollSize)
        {
            transform.position = _target.transform.position + Vector3.up * _scrollSize;
        }
    }
}
