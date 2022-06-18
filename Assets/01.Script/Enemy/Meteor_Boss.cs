using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Boss : MonoBehaviour
{

    private Movement _movement;
    private float _realTime;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        StartCoroutine(Stage1Boss());
    }

    private void Update()
    {
        _realTime += Time.deltaTime;
    }

    

    IEnumerator Stage1Boss()
    {
        while (true)
        {
            if (_realTime <= 6.5 && _realTime >= 9.5)
            {
                print(_realTime);
                StartBossMove();
            }
            yield return null; 
        }
    }


    private void StartBossMove()
    {
        if (_realTime <= 7.5 && _realTime >= 9.5)
            StartCoroutine(MoveToAppearPoint());
    }

    IEnumerator MoveToAppearPoint()
    {
        _movement.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= 3)
                _movement.MoveTo(Vector3.zero);
            yield return null;
        }
    }
}
