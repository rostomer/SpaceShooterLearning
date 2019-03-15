using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour {

    [SerializeField]
    private GameObject _enemyDeathAnimation = null;
    [SerializeField]
    private GameObject _playerDeathAnimation;

    private UI_Manager _UI_Manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Enemy" && other.tag == "Laser")
        {

            //This - Laser, other - Enemy
            gameObject.GetComponent<EnemyBehavior>()._enemyHP--;
            gameObject.GetComponent<AudioSource>().Play();
            if (gameObject.GetComponent<EnemyBehavior>()._enemyHP <= 0)
            {
                Debug.Log("Enemy Killed");

                _UI_Manager.UpdateScore(gameObject.GetComponent<EnemyBehavior>()._enemyScoreValue);


                Instantiate(_enemyDeathAnimation, gameObject.transform.position, Quaternion.identity);
               // _enemyDeathAnimation.gameObject.GetComponent<AudioSource>().Play();

                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }

     if (gameObject.tag == "Player" && (other.tag == "Enemy" || other.tag == "EnemyLaser"))
     {
        gameObject.GetComponent<Player>().
                TakeDamage(1);
            gameObject.GetComponent<AudioPlayer>().PlayeyGetShot();             

            Destroy(other.gameObject);


            if(gameObject.GetComponent<Player>().lives < 1)
            {
                Debug.Log("You are dead");
                Instantiate(_playerDeathAnimation, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                return;
            }

            if (other.tag == "EnemyLaser") return;

            Instantiate(_enemyDeathAnimation, other.gameObject.transform.position, Quaternion.identity);
            _UI_Manager.UpdateScore(other.gameObject.GetComponent<EnemyBehavior>()._enemyScoreValue);
        }
    }

    private void Start()
    {
        _UI_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }
}
