using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBullet : MonoBehaviour
{

    public int _damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
                collision.GetComponent<Meteor_Boss>().Meteor_BossDamge(_damage);
            if(SceneManager.GetActiveScene().buildIndex == 3)
                collision.GetComponent<Staellite_Boss>().Staellite_BossDamge(_damage);
            if (SceneManager.GetActiveScene().buildIndex == 4)
                collision.GetComponent<Space_Station_Boss>().Space_Station_BossDamge(_damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            Destroy (gameObject);
        }
    }
}
