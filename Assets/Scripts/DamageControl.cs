using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour {

    [SerializeField]
    private GameObject _enemyDeathAnimation;
    [SerializeField]
    private GameObject _playerDeathAnimation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && this.gameObject.tag == "Laser")
        {
            Debug.Log("Enemy Killed");

            Instantiate(_enemyDeathAnimation, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

     if (other.tag == "Player" && gameObject.tag == "Enemy")
     {
        other.gameObject.GetComponent<Player>().TakeDamage();

            Destroy(gameObject);
            Instantiate(_enemyDeathAnimation, transform.position, Quaternion.identity);

            if(other.gameObject.GetComponent<Player>().lives < 1)
            {
                Instantiate(_playerDeathAnimation, other.transform.position, Quaternion.identity);
            }
        }

    }
}
