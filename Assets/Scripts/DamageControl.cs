using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
        }

   //     if (other.tag == "Player" && gameObject.tag == "Enemy")
   //     {
    //        other.gameObject.GetComponent<Player>().TakeDamage();
    //    }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
