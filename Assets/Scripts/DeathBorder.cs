using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBorder : MonoBehaviour {


    [SerializeField]
    private GameObject _enemyPrefabToResurrect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyBehavior enemy = other.gameObject.GetComponent<EnemyBehavior>();
            enemy.SetUpPosition();
           // Destroy(other.gameObject);
           // Instantiate(_enemyPrefabToResurrect, transform.position, Quaternion.identity);
      
        }
        else 
        {
            Destroy(other);
        }
    }
	
}
