using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && this.gameObject.tag == "Laser")
        {
            Debug.Log("Enemy Killed");
            Destroy(other.gameObject);
        }

     if (other.tag == "Player" && gameObject.tag == "Enemy")
     {
        other.gameObject.GetComponent<Player>().TakeDamage();
     }

    }
}
