using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {

    [SerializeField]
    private float speed;

    private bool isUpgraded;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        TryDestroyLaser();

        if(Input.GetKeyDown(KeyCode.U))
        {
            isUpgraded = true;
        }

	}

    private void TryDestroyLaser()
    {
        if(transform.position.y > 7.3f)
        {
            Destroy(gameObject);
        }
    }
}
