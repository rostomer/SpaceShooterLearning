using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _PlayerPrefab;

    [SerializeField]
    private GameObject[] _powerUps;

    private float _enemySpawnRate = 4;
    private float _canSpawnPowerUp = 20f;
    private float _PowerUpSpawnRate = 20f;
    private float _canSpawnEnemy = 3;

    private void OnEnable()
    {
        Instantiate(_PlayerPrefab, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
            if (Time.time > _canSpawnEnemy)
            {
                Instantiate(_EnemyPrefab, transform.position, Quaternion.identity);

                _canSpawnEnemy = Time.time + _enemySpawnRate;
            }

            if(Time.time > _canSpawnPowerUp)
            {
            int choice = Random.Range(0, _powerUps.Length);

            Instantiate(_powerUps[choice], new Vector3(Random.Range(-7f, 7f), 9, 0), Quaternion.identity);

            _canSpawnPowerUp = Time.time + _PowerUpSpawnRate;
            }       
    }
}
