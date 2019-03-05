using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {


    private AudioSource _audioSource;
	// Use this for initialization
	void Start () {
        _audioSource = GetComponent<AudioSource>();


        if (gameObject.tag != "PowerUp")
            _audioSource.Play();
	}
	
    public void PowerUpSound()
    {
        if(gameObject.tag =="PowerUp")
        {
            _audioSource.Play();
            if (_audioSource != null)
            AudioSource.PlayClipAtPoint(_audioSource.clip, Vector3.zero, 1f);
        }
    }

	// Update is called once per frame
	void Update () {
        if( gameObject.tag != "PowerUp")
        _audioSource.volume = _audioSource.volume - 0.025f;
	}
}
