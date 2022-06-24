using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            Destroy(gameObject);
            collision.GetComponent<Meteor_Boss>().Meteor_BossDamge(_damage);
            collision.GetComponent<Staellite_Boss>().Staellite_BossDamge(_damage);
        }
    }
}
