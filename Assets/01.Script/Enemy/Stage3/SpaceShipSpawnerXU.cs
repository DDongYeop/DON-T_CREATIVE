using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSpawnerXU : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnTime;

    private ObjectPooler _pooler;

    private void Awake()
    {
        _pooler = GetComponent<ObjectPooler>();
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = Random.Range(_stageData.LimitMin.x, _stageData.LimitMax.x);
            Quaternion rotation = Quaternion.Euler(180, 0, 0);
            //Instantiate(_enemy, new Vector3(positionX, _stageData.LimitMax.y + 1.0f, 0.0f), rotation);

            _pooler.SpawnObject(new Vector3(positionX, _stageData.LimitMax.y + 1.0f, 0.0f), rotation);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
