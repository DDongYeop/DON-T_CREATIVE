using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MeteorBoss { MoveToAppearPoint = 0, Phase01 }

public class Meteor_Boss : MonoBehaviour
{
    [SerializeField] private GameObject _bossBullet;
    [SerializeField] private Vector3 _moveDirection = Vector3.down;
    [SerializeField] private int _damage = 2;
    [SerializeField] private float _maxHP = 200f;
    [SerializeField] private StageData _stageData;

    private float _realTime;
    private float _currentHP;
    private bool _bossDie = true;
    private bool _bossPhase2 = true;
    private bool _start = true;

    private void Start()
    {
        _currentHP = _maxHP;
    }

    private void Update()
    {
        _realTime += Time.deltaTime;

        if (_realTime > 70)
            StopCoroutine(MoveToAppearPoint());

        if (_currentHP <= 0 && _bossDie == true)
        {
            StopAllCoroutines();
            StartCoroutine(Meteor_Boss_Die());
            _bossDie = false;
        }

        if (_currentHP <= _maxHP * 0.5f && _bossPhase2 == true)
        {
            StartCoroutine(BackAndForth());
            _bossPhase2 = false;
        }

        if (_realTime >= 66 && _start == true)
        {
            StartCoroutine(MoveToAppearPoint());
            _start = false;
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

            if (_realTime >= 70)
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
                transform.position += dir * 7 * Time.deltaTime;

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
            Meteor_Boss_Phase1();
            yield return new WaitForSeconds(0.2f);
            Meteor_Boss_Phase1();
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<Renderer>().material.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(7);
            break;
        }
    }

    private void Meteor_Boss_Phase1()
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

    IEnumerator BackAndForth()
    {
        Vector3 _dir = Vector3.right;

        while (true)
        {
            transform.position += _dir * 4 * Time.deltaTime;
            if (transform.position.x <= _stageData.LimitMin.x + 1.4f || transform.position.x >= _stageData.LimitMax.x - 1.4f)
            {
                _dir *= -1;
                transform.position += _dir * 4 * Time.deltaTime;
            }
            yield return null;
        }
    }

    public void MeteorBossPlayer()
    {
        StopAllCoroutines();
        SceneManager.LoadScene(12);
    }
}
