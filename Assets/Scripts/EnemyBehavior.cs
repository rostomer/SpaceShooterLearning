using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    [SerializeField]
    private float _enemySpeed = 2f;

    [SerializeField]
    private float leftSpawnBorder;
    [SerializeField]
    private float rightSpawnBorder;
    [SerializeField]
    private float topSpawnBorder;

    private float xSpawnPos;

	// Use this for initialization
	void Start () {
        xSpawnPos = Random.Range(leftSpawnBorder, rightSpawnBorder);
        transform.position = new Vector3(xSpawnPos, topSpawnBorder, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
	}
}
