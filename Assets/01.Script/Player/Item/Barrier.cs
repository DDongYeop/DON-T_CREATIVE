using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject _barriar;

    private BarriarScript _barriarScript;

    private void Awake()
    {
        _barriarScript = GameObject.Find("Berrier").GetComponent<BarriarScript>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _barriarScript.BarriarScriptStart();
            Destroy(gameObject);
        }
    }
}
