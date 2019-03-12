using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 _laserDirection;

    private bool isUpgraded;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(_laserDirection * speed * Time.deltaTime);

        TryDestroyLaser();

        if(Input.GetKeyDown(KeyCode.U))
        {
            isUpgraded = true;
        }

	}

    private void TryDestroyLaser()
    {
        if(transform.position.y > 7.3f || transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
