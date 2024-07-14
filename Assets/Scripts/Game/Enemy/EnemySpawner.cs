using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _minimunSpawnTime;

    [SerializeField]
    private float _maximunSpawnTime;

    private float _timeUntilSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUnitilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn < 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUnitilSpawn();
        }
    }
    private void SetTimeUnitilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimunSpawnTime, _maximunSpawnTime);
    }


}
