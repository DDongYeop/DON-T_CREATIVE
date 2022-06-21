using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeteorBoss { MoveToAppearPoint = 0, Phase01 }

public class Meteor_Boss : MonoBehaviour
{
    [SerializeField] private GameObject _bossBullet;
    [SerializeField] private Vector3 _moveDirection = Vector3.down;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _maxHP = 200f;

    private float _realTime;
    private float _currentHP;
    private bool _BossDie = true;

    private void Start()
    {
        _currentHP = _maxHP;
        StartCoroutine(MoveToAppearPoint());
    }

    private void Update()
    {
        _realTime += Time.deltaTime;

        /*if (_realTime >= 6.5 && _realTime <= 9)
            StartCoroutine(MoveToAppearPoint());
        else 
            StopCoroutine(MoveToAppearPoint());*/

        /*if (_realTime >= 11 && _realTime <= 11.1f)
            StartCoroutine(BossPettern1());*/

        if (_realTime > 11)
            StopCoroutine(MoveToAppearPoint());

        if (_currentHP == 0 && _BossDie == true)
        {
            StopAllCoroutines();
            StartCoroutine(Meteor_Boss_Die());
            _BossDie = false;
        }
    }

    IEnumerator MoveToAppearPoint()
    {
        yield return new WaitForSeconds(6.5f);
     

        while (true)
        {
            transform.position += _moveDirection * 5 * Time.deltaTime;

            if (transform.position.y <= 2.5f)
            {
                _moveDirection = Vector3.zero;
            }

            if (_realTime >= 11)
            {
                StartCoroutine(BossPettern1());
                break;
            }
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

#region Phase1 ÇÔ¼öµé
    private float _attRate = 3f;
    private int _count = 20;
    private float _intercalAngle;
    private float _weightAngle = 0;
#endregion

    IEnumerator BossPettern1()
    {
        _intercalAngle = 360 / _count;

        while (true)
        {
            for (int i = 0; i < _count; ++i)
            {
                GameObject clone = Instantiate(_bossBullet, transform.position, Quaternion.identity);

                float angle = _weightAngle + _intercalAngle * i;

                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

                Vector3 dir = new Vector3(x, y, 0);
                transform.position += dir * 5 * Time.deltaTime;

                clone.GetComponent<Movement>().MoveTo(dir);
            }

            _weightAngle += 1;
            yield return new WaitForSeconds(_attRate);
        }
    }

    IEnumerator Meteor_Boss_Die()
    {
        while (true)
        {
            Meteor_Boss_Phase1();
            yield return new WaitForSeconds(0.2f);
            Meteor_Boss_Phase1();
            yield return new WaitForSeconds(0.2f);
            Meteor_Boss_Phase1();
            yield return new WaitForSeconds(0.2f);
            BossDestroy();
            break;
        }
    }

    void Meteor_Boss_Phase1()
    {
        for (int i = 0; i < _count; ++i)
        {
            GameObject clone = Instantiate(_bossBullet, transform.position, Quaternion.identity);

            float angle = _weightAngle + _intercalAngle * i;

            float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

            Vector3 dir = new Vector3(x, y, 0);
            transform.position += dir * 5 * Time.deltaTime;

            clone.GetComponent<Movement>().MoveTo(dir);
        }

        _weightAngle += 1;
    }

    void BossDestroy()
    {
        Destroy(gameObject);
        StopAllCoroutines();
    }
}
