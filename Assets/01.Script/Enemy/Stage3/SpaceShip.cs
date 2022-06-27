using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private float _damage = 1;
    [SerializeField] private int _score = 100;
    [SerializeField] private GameObject _recoveryItem;
    [SerializeField] private GameObject _barrierItem;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamge(_damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Playerbullet"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Playerbullet"))
        {
            PlayerScoreViewer.score += _score;

            int ItemSpawnH = Random.Range(0, 100);
            int ItemSpawnB = Random.Range(0, 100);

            if (ItemSpawnH <= 7)
            {
                GameObject revoveryItem = Instantiate(_recoveryItem);
                revoveryItem.transform.position = transform.position;
            }

            if (ItemSpawnB <= 7)
            {
                GameObject barrierItem = Instantiate(_barrierItem);
                barrierItem.transform.position = transform.position;
            }
            Destroy(gameObject);
        }
    }

}
