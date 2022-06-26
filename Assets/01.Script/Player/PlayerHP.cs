using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float _maxHP = 10;

    private SpriteRenderer _spriteRenderer;
    private PlayerController _playerController;

    public float currentHP;

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
            return currentHP;
        }
    }


    private void Awake()
    {
        currentHP = _maxHP;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (currentHP >= 10)
            currentHP = 10;
    }


    public void TakeDamge(float damage)
    {
        currentHP -= damage;
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if (currentHP <= 0)
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
