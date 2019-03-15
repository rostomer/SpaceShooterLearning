using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(GameEndCourotine());
	}
	
    private IEnumerator GameEndCourotine()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.isGameActive = false;
        GameManager.instance.EndOfTheGame();
        Destroy(gameObject);
    }
}
