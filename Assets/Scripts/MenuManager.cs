using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] _unactiveObjects;

    [SerializeField]
    private Image _menuImage;

    private UI_Manager _UI_Manager;

    private bool _objectsAreActive = false;
	// Use this for initialization
	void Start () {
        _UI_Manager = GetComponent<UI_Manager>();
	}


    public void StartGame()
    {
            foreach (GameObject obj in _unactiveObjects)
            {
                obj.SetActive(!_objectsAreActive);
            }
            _objectsAreActive = !_objectsAreActive;
    }

    public void ReactivateMenu()
    {
        foreach (GameObject obj in _unactiveObjects)
        {
            obj.SetActive(!_objectsAreActive);
        }
        _objectsAreActive = !_objectsAreActive;

        GameObject[] notDeadEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] lasersInFly = GameObject.FindGameObjectsWithTag("Laser");
        GameObject[] notPickedPowerUps = GameObject.FindGameObjectsWithTag("PowerUp");

        foreach(GameObject enemy in notDeadEnemies)
        {
            Destroy(enemy);
        }
        foreach(GameObject laser in lasersInFly)
        {
            Destroy(laser);
        }
        foreach(GameObject powerUp in notPickedPowerUps)
        {
            Destroy(powerUp);
        }

        _menuImage.gameObject.SetActive(true);

        _UI_Manager.CurrentScore = 0;
        _UI_Manager.UpdateScore(_UI_Manager.CurrentScore);
    }
}
