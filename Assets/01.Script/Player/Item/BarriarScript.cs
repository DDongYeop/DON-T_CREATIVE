using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarriarScript : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private GameObject _barriar;

    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
                collision.GetComponent<Meteor_Boss>().Meteor_BossDamge(_damage);
            if (SceneManager.GetActiveScene().buildIndex == 3)
                collision.GetComponent<Staellite_Boss>().Staellite_BossDamge(_damage);
            if (SceneManager.GetActiveScene().buildIndex == 4)
                collision.GetComponent<Space_Station_Boss>().Space_Station_BossDamge(_damage);
        }
    }

    public void BarriarScriptStart()
    {
        _spriteRenderer.color = Color.white;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(BarriarFalse());
    }

    IEnumerator BarriarFalse()
    {
        yield return new WaitForSeconds(7.5f);
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        _spriteRenderer.color = Color.clear;
    }
}
