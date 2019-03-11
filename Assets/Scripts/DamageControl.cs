using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour {

    [SerializeField]
    private GameObject _enemyDeathAnimation;
    [SerializeField]
    private GameObject _playerDeathAnimation;

    private UI_Manager _UI_Manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && this.gameObject.tag == "Laser")
        {
            other.gameObject.GetComponent<EnemyBehavior>()._enemyHP--;
            other.gameObject.GetComponent<AudioSource>().Play();
            if (other.gameObject.GetComponent<EnemyBehavior>()._enemyHP <= 0)
            {
                Debug.Log("Enemy Killed");

                Instantiate(_enemyDeathAnimation, other.transform.position, Quaternion.identity);

                _UI_Manager.UpdateScore(other.gameObject.GetComponent<EnemyBehavior>()._enemyScoreValue);

                _enemyDeathAnimation.gameObject.GetComponent<AudioSource>().Play();

                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }

     if (other.tag == "Player" && (gameObject.tag == "Enemy" || gameObject.tag == "EnemyLaser"))
     {
        other.gameObject.GetComponent<Player>().
                TakeDamage(1);

            Destroy(gameObject);


            if(other.gameObject.GetComponent<Player>().lives < 1)
            {
                Instantiate(_playerDeathAnimation, other.transform.position, Quaternion.identity);
                _UI_Manager.ActivateMenu();

                return;
            }

            if (gameObject.tag == "EnemyLaser") return;

            Instantiate(_enemyDeathAnimation, transform.position, Quaternion.identity);
            _UI_Manager.UpdateScore(gameObject.GetComponent<EnemyBehavior>()._enemyScoreValue);
        }
    }

    private void Start()
    {
        _UI_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }
}
