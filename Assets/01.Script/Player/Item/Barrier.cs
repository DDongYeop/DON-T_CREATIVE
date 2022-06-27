using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject _barriar;

    private BarriarScript _barriarScript;
    private ObjectPooler _pooler;

    private void Awake()
    {
        _barriarScript = GameObject.Find("Berrier").GetComponent<BarriarScript>();
        _pooler = GetComponent<ObjectPooler>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _barriarScript.BarriarScriptStart();
            _pooler.ReturnObject(gameObject);
        }
    }
}
