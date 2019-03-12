using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    [SerializeField]
    private AudioClip originalShotAudioClip;
    [SerializeField]
    private AudioClip playerGotShotAudioClip;

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

    public void LaserShotSound()
    {
        if(gameObject.tag == "EnemyLaser")
        {
            AudioSource.PlayClipAtPoint(_audioSource.clip, Vector3.zero, 1f);
        }
    }
    public void PlayeyGetShot()
    {
        if (gameObject.tag == "Player")
        {
            _audioSource.clip = playerGotShotAudioClip;

            AudioSource.PlayClipAtPoint(_audioSource.clip, Vector3.zero, 1f);
        }

        _audioSource.clip = originalShotAudioClip;
    }
	// Update is called once per frame
	void Update () {
        

        if( gameObject.tag != "PowerUp")
        _audioSource.volume = _audioSource.volume - 0.025f;
	}
}
