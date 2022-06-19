using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Boss : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection = Vector3.down;
    [SerializeField] private int _damage = 2;

    private float _realTime;


    private void Update()
    {
        _realTime += Time.deltaTime;

        if (_realTime >= 6.5 && _realTime <= 9)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerHP>().TakeDamge(_damage);
    }
}
