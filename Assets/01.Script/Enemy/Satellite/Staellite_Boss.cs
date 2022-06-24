using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staellite_Boss : MonoBehaviour
{
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _maxHP = 200f;
    [SerializeField] private StageData _stageData;

    private Vector3 _moveDirection = Vector3.down;
    private float _realTime;
    private float _currentHP;

    private bool _start = true;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    private void Update()
    {
        _realTime += Time.deltaTime;

        if (_realTime >= 66 && _start == true)
        {
            StartCoroutine(MoveToAppearPoint());
            _start = false;
        }
        if (_realTime > 71)
            StopCoroutine(MoveToAppearPoint());
    }

    IEnumerator MoveToAppearPoint()
    {
        while (true)
        {
            transform.position += _moveDirection * 5 * Time.deltaTime;

            if (transform.position.y <= 2.5f)
            {
                _moveDirection = Vector3.zero;
            }

            if (_realTime >= 71)
            {
                //StartCoroutine(BossPettern1());
                break;
            }
            yield return null;
        }
    }
}
