using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprite;

    private SpriteRenderer _spriteRenderer;
    private PlayerBullet _playerBullet;

    private void Awake()
    {
        _playerBullet = GetComponent<PlayerBullet>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageScriptStart()
    {
        StartCoroutine(DamageScriptStartCo());
    }

    IEnumerator DamageScriptStartCo()
    {
        _spriteRenderer.sprite = _sprite[1];
        _playerBullet._damage = 2;
        yield return new WaitForSeconds(10f);
        _spriteRenderer.sprite = _sprite[0];
        _playerBullet._damage = 1;
    }
}
