using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private UI_Manager _UI_Manager;
    [SerializeField]
    [Range(1,3)]
    private int _gameDifficulty = 1;
    [SerializeField]
    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject EnemyPrefab;

    private float difficaltyIncreaseRate = 15f;
    private float timePassedFromPreviousIncrease = 0f;

    private float difficaltyChanger = 0f;
    // Use this for initialization
    void Start () {
       // ChangeParametersByGameDifficulty(_gameDifficulty);
	}
	
	// Update is called once per frame
	void Update () {
        StartGame();
        if(_spawnManager.gameObject.activeSelf)
        {
            ChangeParametersByGameDifficulty(_gameDifficulty);
        }
	}

    private void StartGame()
    {
        if (_UI_Manager.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space) && !_UI_Manager._objectsAreActive)
        {
            _UI_Manager.ActivateMenu();
        }
    }

    private void ChangeParametersByGameDifficulty(int difficultyLevel)
    {
        
        if(difficultyLevel == 3)
        {
            difficaltyIncreaseRate = 10f;
            if(Time.time > timePassedFromPreviousIncrease)
            {
                 _spawnManager._enemySpawnRate = 1.5f - difficaltyChanger;
                //_spawnManager._canSpawnPowerUp = 40f;
                _spawnManager._PowerUpSpawnRate = 40f + difficaltyChanger * 9;

                timePassedFromPreviousIncrease = Time.time + difficaltyIncreaseRate;

                if (difficaltyChanger <= 1.3f)
                    difficaltyChanger += 0.05f;
            }


            EnemyPrefab.GetComponent<EnemyBehavior>()._enemyHP = 3;
        }
        else if(difficultyLevel == 2)
        {
            difficaltyIncreaseRate = 15f;
            if (Time.time > timePassedFromPreviousIncrease)
            {
                _spawnManager._enemySpawnRate = 2f - difficaltyChanger;
                //_spawnManager._canSpawnPowerUp = 40f;
                _spawnManager._PowerUpSpawnRate = 3f + difficaltyChanger * 4;

                timePassedFromPreviousIncrease = Time.time + difficaltyIncreaseRate;

                if (difficaltyChanger <= 1.1f)
                    difficaltyChanger += 0.03f;
            }


            EnemyPrefab.GetComponent<EnemyBehavior>()._enemyHP = 2;
        }
        else if (difficultyLevel == 1)
        {
            difficaltyIncreaseRate = 20f;
            if (Time.time > timePassedFromPreviousIncrease)
            {
                _spawnManager._enemySpawnRate = 2.2f - difficaltyChanger;
                //_spawnManager._canSpawnPowerUp = 40f;
                _spawnManager._PowerUpSpawnRate = 15f + difficaltyChanger * 5;

                timePassedFromPreviousIncrease = Time.time + difficaltyIncreaseRate;

                if (difficaltyChanger <= 1.1f)
                    difficaltyChanger += 0.02f;
            }


            EnemyPrefab.GetComponent<EnemyBehavior>()._enemyHP = 1;
        }
    }
}
