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

    [SerializeField]
    private GameObject _laser;

    private float _laserSpawnRate = 4f;
    private float _shootDelay = 0f;
   // private float firstShootDelay = 3f;

    [SerializeField]
    public int _enemyScoreValue;
    [SerializeField]
    public int _enemyHP = 1;

    private float xSpawnPos;

	// Use this for initialization
	void Start () {
        SetUpPosition();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        _shootDelay += Time.deltaTime;

        if (_shootDelay > _laserSpawnRate)
        {
            Instantiate(_laser, transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);

            gameObject.GetComponent<AudioSource>().Play();

            _shootDelay = 0f;
        }

	}

    public void SetUpPosition()
    {
        xSpawnPos = Random.Range(leftSpawnBorder, rightSpawnBorder);
        transform.position = new Vector3(xSpawnPos, topSpawnBorder, 0);
    }
}
