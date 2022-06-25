using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerY : MonoBehaviour
{
    [SerializeField] private StageData _stageData;
    [SerializeField] private GameObject _enemy;
    public float spawnTimeY;

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionY = Random.Range(_stageData.LimitMin.y, _stageData.LimitMax.y);
            Instantiate(_enemy, new Vector3(_stageData.LimitMax.y + 5.5f, positionY, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(spawnTimeY);
        }
    }
}
