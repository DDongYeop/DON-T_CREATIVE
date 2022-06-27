using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_Station_Boss_Bulelt : MonoBehaviour
{
    [SerializeField] private float _damage = 1;
    [SerializeField] private int _score = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamge(_damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Playerbullet"))
        {
            PlayerScoreViewer.score += _score;
            Destroy(gameObject);
        }
    }
}
