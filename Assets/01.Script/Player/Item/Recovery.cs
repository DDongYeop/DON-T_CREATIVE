using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour
{
    private PlayerHP _playerHP;

    private void Awake()
    {
        _playerHP = GameObject.Find("Player").GetComponent<PlayerHP>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerHP.GetComponent<PlayerHP>().currentHP++;
            Destroy(gameObject);
        }
    }
}
