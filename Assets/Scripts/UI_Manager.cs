using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    [SerializeField]
    private Image livesImage;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _liveSprites;

    //All unactive objects at the game start
    [SerializeField]
    private GameObject[] _unactiveObjects;

    public bool _objectsAreActive = false;

    public int CurrentScore { get; set; }

    //   private GameObject player;

    public void UpdateLives(int lives)
    {
        Debug.Log("Player lives: " + lives);
        try
        {
            livesImage.sprite = _liveSprites[lives];
        }
        catch(Exception e)
        {
            Debug.Log(e.ToString() + " was caught.");
        }
    }

    public void UpdateScore(int scoreValueToAdd)
    {
        CurrentScore += scoreValueToAdd;
        _scoreText.text = "Score: " + CurrentScore;
    }
}
