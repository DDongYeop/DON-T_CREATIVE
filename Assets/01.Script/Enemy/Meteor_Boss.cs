using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Boss : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection = Vector3.down;

    private Movement _movement;
    private float _realTime;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        _realTime += Time.deltaTime;

        if (_realTime >= 6.5 && _realTime <= 8)
            StartCoroutine(MoveToAppearPoint());
        else 
            StopCoroutine(MoveToAppearPoint());
    }

    IEnumerator MoveToAppearPoint()
    {
        transform.position += _moveDirection * 5 * Time.deltaTime;

        while (true)
        {
            if (transform.position.y <= 2.5f)
                _moveDirection = Vector3.zero;
            yield return null;
        }
    }
}
