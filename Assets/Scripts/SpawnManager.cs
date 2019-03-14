using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _Enemy_big_Prefab;
    [SerializeField]
    private GameObject _PlayerPrefab;

    [SerializeField]
    private GameObject[] _powerUps;

    public float _enemySpawnRate
    {
        get;
        set;
    }
    public float _PowerUpSpawnRate
    {
        get;
        set;
    }


    private float _canSpawnPowerUp = 30f;
    private float _canSpawnEnemy = 3;

    private float time;

    private void OnEnable()
    {
        Instantiate(_PlayerPrefab, Vector3.zero, Quaternion.identity);
        GameManager.instance.ChangeParametersByGameDifficulty(GameManager.instance._gameDifficulty);
    }

    private void OnDisable()
    {
        GameManager.instance.ChangeParametersByGameDifficulty(GameManager.instance._gameDifficulty);
        //_enemySpawnRate = 0f;
        //_PowerUpSpawnRate = 0f;
        _canSpawnPowerUp = 30f;
        _canSpawnEnemy = 3f;
    }

    void Update()
    {
        time = Time.timeSinceLevelLoad;

            if (time > _canSpawnEnemy)
            {
                if(Random.Range(0,5) < 4)
                    Instantiate(_EnemyPrefab, transform.position, Quaternion.identity);
                else if(Random.Range(0,5) == 4)
                {
                Instantiate(_Enemy_big_Prefab, transform.position, Quaternion.identity);
            }
                _canSpawnEnemy = time + _enemySpawnRate;
            }

            if(time > _canSpawnPowerUp)
            {
            int choice = Random.Range(0, _powerUps.Length);

            Instantiate(_powerUps[choice], new Vector3(Random.Range(-7f, 7f), 9, 0), Quaternion.identity);

            Debug.Log(_PowerUpSpawnRate);

            _canSpawnPowerUp = time + _PowerUpSpawnRate;
            }       
    }
}
