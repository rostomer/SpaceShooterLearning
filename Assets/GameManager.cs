using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private UI_Manager _UI_Manager;
    [SerializeField]
    [Range(1,3)]
    private int gameDifficulty = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartGame();
	}

    private void StartGame()
    {
        if (_UI_Manager.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space) && !_UI_Manager._objectsAreActive)
        {
            _UI_Manager.ActivateMenu();
        }
    }
}
