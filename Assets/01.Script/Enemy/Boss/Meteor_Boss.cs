using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Boss : MonoBehaviour
{
    [SerializeField] private GameObject _bossBullet;
    [SerializeField] private Vector3 _moveDirection = Vector3.down;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _maxHP = 200f;

    private float _realTime;
    private float _currentHP;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    private void Update()
    {
        _realTime += Time.deltaTime;

        if (_realTime >= 6.5 && _realTime <= 9)
            StartCoroutine(MoveToAppearPoint());
        else 
            StopCoroutine(MoveToAppearPoint());

        if (_currentHP <= 0)
            MeteorBossDie();

        if (_realTime >= 71 && _realTime <= 73)
            StartCoroutine(BossPettern1());
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

    public void Meteor_BossDamge(int damage)
    {
        _currentHP -= damage;
    }

    private void MeteorBossDie()
    {
        Destroy(gameObject);
    }

    IEnumerator BossPettern1()
    {
        float attRate = 0.5f;
        int count = 30;
        float intercalAngle = 360 / count;
        float weightAngle = 0;

        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(_bossBullet, transform.position, Quaternion.identity);

                float angle = weightAngle + intercalAngle * i;

                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

                Vector3 dir = new Vector3(x, y, 0);
                transform.position += dir * 5 * Time.deltaTime;
            }

            weightAngle += 1;
            yield return new WaitForSeconds(attRate);
        }
    }
}
