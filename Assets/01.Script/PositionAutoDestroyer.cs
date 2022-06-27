using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    private float _destroyWeight = 2.0f;

    //ObjectPooler bulletPooler;
    ObjectPooler _pooler;

    private void Start()
    {
        //bulletPooler = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectPooler>();
        //enemyPooler = GameObject.Find("EnemySpawner").GetComponent<ObjectPooler>();
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            _pooler = GameObject.Find("SpaceShipSpawner").GetComponent<ObjectPooler>();
        }
    }
    void LateUpdate()
    {
        if (transform.position.x < _stageData.LimitMin.x - _destroyWeight ||
            transform.position.x > _stageData.LimitMax.x + _destroyWeight ||
            transform.position.y < _stageData.LimitMin.y - _destroyWeight ||
            transform.position.y > _stageData.LimitMax.y + _destroyWeight)
        {
            if (gameObject.CompareTag("Playerbullet"))
            {
                //bulletPooler.ReturnObject(gameObject);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Enemy"))
            {
                if(GameObject.Find("SpaceShip(Clone)"))
                    _pooler.ReturnObject(gameObject);
                //Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }
}
