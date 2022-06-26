using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    private DamageScript _damageScript;

    private void Awake()
    {
        _damageScript = _bullet.GetComponent<DamageScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(_damageScript);
        if (collision.CompareTag("Player"))
        {
            _damageScript.DamageScriptStart();
            Destroy(gameObject);
        }
    }
}
