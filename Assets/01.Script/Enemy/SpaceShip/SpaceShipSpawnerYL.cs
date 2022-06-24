using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSpawnerYL : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _spawnTime;

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            float positionY = Random.Range(_stageData.LimitMin.y, _stageData.LimitMax.y);
            Quaternion rotation = Quaternion.Euler(0, 0, 270);
            Instantiate(_enemy, new Vector3(_stageData.LimitMin.y - 5.5f, positionY, 0.0f), rotation);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
