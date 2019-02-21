using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour {

    private float _waitTimeForDestruction = 2.5f;

    private float _selfDestructionTimer;

	// Use this for initialization
	void Start () {
        _selfDestructionTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > _selfDestructionTimer + _waitTimeForDestruction)
        {
            Destroy(gameObject);
        }
	}
}
