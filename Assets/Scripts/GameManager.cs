using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private UI_Manager _UI_Manager;
    [SerializeField]
    [Range(1,3)]
    public int _gameDifficulty = 1;
    [SerializeField]
    private SpawnManager _spawnManager;
    [SerializeField]
    private GameObject EnemyPrefab;

    private float difficultyIncreaseRate = 15f;
    private float timePassedFromPreviousIncrease = 0f;

    private float difficultyChanger = 0f;

    public static GameManager instance;
    [HideInInspector]
    public bool isGameActive;
    // Use this for initialization
    void Start () {
        if(instance == null)
        {
            instance = this;
        } else if(instance == this)
        {
            Destroy(gameObject);
        }

        _gameDifficulty = GameSettingsManager.instance.difficultyLevel;
        StartGame();
    }
	
	// Update is called once per frame
	void Update () {

        if(_spawnManager.gameObject.activeSelf)
        {
            ChangeParametersByGameDifficulty(_gameDifficulty);
        }
        else
        {
            difficultyChanger = 0f;
        }
	}

    private void StartGame()
    {
        //Костыль, вырезать к чёрту отсюда и удалить тот класс.
        GameObject.Find("Canvas").GetComponent<MenuManager>().StartGame();
            isGameActive = true;
       
    }

    public void ChangeParametersByGameDifficulty(int difficultyLevel)
    {
        
        if(difficultyLevel == 3)
        {
            difficultyIncreaseRate = 10f;
            if(Time.time > timePassedFromPreviousIncrease)
            {
                 _spawnManager._enemySpawnRate = 1.5f - difficultyChanger;
                _spawnManager._PowerUpSpawnRate = 40f + difficultyChanger * 9;

                timePassedFromPreviousIncrease = Time.time + difficultyIncreaseRate;

                if (difficultyChanger <= 1.3f)
                    difficultyChanger += 0.05f;
            }


            EnemyPrefab.GetComponent<EnemyBehavior>()._enemyHP = 3;
        }
        else if(difficultyLevel == 2)
        {
            difficultyIncreaseRate = 15f;
            if (Time.time > timePassedFromPreviousIncrease)
            {
                _spawnManager._enemySpawnRate = 2f - difficultyChanger;
                _spawnManager._PowerUpSpawnRate = 30f + difficultyChanger * 4;

                timePassedFromPreviousIncrease = Time.time + difficultyIncreaseRate;

                if (difficultyChanger <= 1.1f)
                    difficultyChanger += 0.03f;
            }


            EnemyPrefab.GetComponent<EnemyBehavior>()._enemyHP = 2;
        }
        else if (difficultyLevel == 1)
        {
            difficultyIncreaseRate = 20f;
            if (Time.time > timePassedFromPreviousIncrease)
            {
                _spawnManager._enemySpawnRate = 2.2f - difficultyChanger;
                _spawnManager._PowerUpSpawnRate = 15f + difficultyChanger * 5;

                timePassedFromPreviousIncrease = Time.time + difficultyIncreaseRate;

                if (difficultyChanger <= 1.1f)
                    difficultyChanger += 0.02f;
            }


            EnemyPrefab.GetComponent<EnemyBehavior>()._enemyHP = 1;
        }
    }

    public void EndOfTheGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
