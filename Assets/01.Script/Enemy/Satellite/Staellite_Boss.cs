using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staellite_Boss : MonoBehaviour
{
    [SerializeField] private GameObject _bossBullet;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _maxHP = 200f;
    [SerializeField] private StageData _stageData;

    private Vector3 _moveDirection = Vector3.down;
    private float _realTime;
    private float _currentHP;

    private bool _start = true;
    private bool _bossPhase2 = true;

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

        if (_currentHP <= _maxHP * 0.75f && _bossPhase2 == true )
        {
            StartCoroutine(BackAndForth());
            _bossPhase2 = false;
        }
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
                StartCoroutine(BossPettern1());
                break;
            }
            yield return null;
        }
    }

    IEnumerator BossPettern1()
    {
        _intercalAngle = 360 / _count;

        while (true)
        {
            Staellite_Boss_Phase1();
            yield return new WaitForSeconds(_attRate);
        }
    }


    IEnumerator BackAndForth()
    {
        Vector3 _dir = Vector3.right;

        while (true)
        {
            transform.position += _dir * 5.5f * Time.deltaTime;
            if (transform.position.x <= _stageData.LimitMin.x + 1.4f || transform.position.x >= _stageData.LimitMax.x - 1.4f)
            {
                _dir *= -1;
                transform.position += _dir * 5.5f * Time.deltaTime;
            }
            yield return null;
        }
    }





    #region Phase1 ÇÔ¼öµé
    private float _attRate = 2.5f;
    private int _count = 25;
    private float _intercalAngle;
    private float _weightAngle = 0;
    #endregion

    private void Staellite_Boss_Phase1()
    {
        for (int i = 0; i < _count; ++i)
        {
            GameObject clone = Instantiate(_bossBullet, transform.position, Quaternion.identity);

            float angle = _weightAngle + _intercalAngle * i;

            float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f);

            Vector3 dir = new Vector3(x, y, 0);
            transform.position += dir * 7 * Time.deltaTime;

            clone.GetComponent<Movement>().MoveTo(dir);
        }

        _weightAngle += 1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerHP>().TakeDamge(_damage);
    }


    public void Staellite_BossDamge(int damage)
    {
        _currentHP -= damage;
    }
}
