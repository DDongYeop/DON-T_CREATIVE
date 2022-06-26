using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float _maxHP = 10;
    private float _currentHP;
    private SpriteRenderer _spriteRenderer;
    private PlayerController _playerController;

    public float MaxHP
    {
        get
        {
            return _maxHP;
        }
    }

    public float CurrentHP
    {
        get
        {
            return _currentHP;
        }
    }


    private void Awake()
    {
        _currentHP = _maxHP;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerController = GetComponent<PlayerController>();
    }


    public void TakeDamge(float damage)
    {
        _currentHP -= damage;
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if (_currentHP <= 0)
        {
            _playerController.Die();
        }
    }

    IEnumerator HitColorAnimation()
    {
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _spriteRenderer.color = Color.white;
    }
}
