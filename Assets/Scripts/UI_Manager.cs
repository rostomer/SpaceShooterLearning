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
            livesImage.sprite = _liveSprites[lives];
    }

    public void UpdateScore(int scoreValueToAdd)
    {
        CurrentScore += scoreValueToAdd;
        _scoreText.text = "Score: " + CurrentScore;
    }
	// Use this for initialization
	
    public void ActivateMenu()
    {
            foreach (GameObject obj in _unactiveObjects)
            {
                obj.SetActive(_objectsAreActive);
            }
            _objectsAreActive = !_objectsAreActive;
    }

	// Update is called once per frame
	//void Update () {
 //       if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space) && !_objectsAreActive)
 //       {
 //           ActivateMenu();
 //       }

 //   }
}
