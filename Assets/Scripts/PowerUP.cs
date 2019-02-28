using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private string powerUpType;
	// Use this for initialization
	void Start () {
        
	}
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null && powerUpType == "Triple")
            {
                player.PowerUpOn(powerUpType);
            }
            else if(player != null && powerUpType == "Speed")
            {
                player.PowerUpOn(powerUpType);
            }
            else if(player != null && powerUpType == "Shield")
            {
                player.PowerUpOn(powerUpType);
            }

            Destroy(gameObject);
        }

        
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
}
