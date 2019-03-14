using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private float _fireRate = 0.25f;

    [SerializeField]
    private float _canFire;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _trippleshotPrefab;
    [SerializeField]
    private GameObject _shieldPrefab;

    private float _horizontalInput;
    private float _verticalInput;

    public int lives = 3;

    
    private bool _isTripleLaserPicked;
    private bool _isSpeedPowerUpPicked;
    private bool _isShieldPowerUpPicked;

    [SerializeField]
    private GameObject[] engines;

    private GameObject _shield;

    private UI_Manager _uI_Manager;
    private MenuManager _menuManager;

    private AudioSource _audioSource;

    public AudioClip playerGetShot;

    private Vector3 movementVector = new Vector3(1, 1, 0);
	// Use this for initialization
	void Start () {
        Debug.Log(movementVector);

        _uI_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();

        if (_uI_Manager != null)
        {
            Debug.Log("Lives Updated");
            _uI_Manager.UpdateLives(lives);
        }

        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Movemevt();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > _canFire)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
       // _audioSource.Play();

        AudioSource.PlayClipAtPoint(_audioSource.clip, Vector3.zero, 2f);
       
        if(_isTripleLaserPicked)
        {
            Instantiate(_trippleshotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
        }
            _canFire = Time.time + _fireRate;
            
    }

    public void PowerUpOn(string powerType)
    {
        if(powerType == "Triple")
        {
            _isTripleLaserPicked = true;
            StartCoroutine(ShutDownTriplePowerUpOn());
        }
        else if(powerType == "Speed")
        {
            _isSpeedPowerUpPicked = true;
            StartCoroutine(ShutDownSpeedUp());
        }
        else if(powerType == "Shield")
        {
            _isShieldPowerUpPicked = true;
            StartCoroutine(ShutDownShield());
        }
       
    }

    private IEnumerator ShutDownTriplePowerUpOn()
    {
        yield return new WaitForSeconds(10);
        _isTripleLaserPicked = false;
    }

    private IEnumerator ShutDownSpeedUp()
    {
        _speed *= 2;

        yield return new WaitForSeconds(10);

        _speed /= 2;
        _isSpeedPowerUpPicked = false;
    }

    private IEnumerator ShutDownShield()
    {
        _shield = Instantiate(_shieldPrefab, transform.position, Quaternion.identity);

        _shield.transform.parent = gameObject.transform;

        yield return new WaitForSeconds(15);

        Destroy(_shield);
        _shield = null;

        _isShieldPowerUpPicked = false;
    }


    private void Movemevt()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        movementVector.x = _horizontalInput * 1;
        movementVector.y = _verticalInput * 1;



        transform.Translate(movementVector * _speed * Time.deltaTime);
       
        if (transform.position.y < -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, transform.position.z);
        }
        else if (transform.position.y > 2)
        {
            transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        }
        else if (transform.position.x < -11f)
        {
            transform.position = new Vector3(11f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 11f)
        {
            transform.position = new Vector3(-11f, transform.position.y, transform.position.z);
        }
    }

    public void TakeDamage(int damageTaken)
    {
        if (_isShieldPowerUpPicked)
        {
            _isShieldPowerUpPicked = false;
            Destroy(_shield);
            _shield = null;
        }
        else
        {
            lives -= damageTaken;

            if(lives == 2 && !engines[0].activeSelf)
            {
                engines[0].SetActive(true);
            }
            else if(lives == 1 && !engines[1].activeSelf)
            {
                engines[1].SetActive(true);
            }
            _uI_Manager.UpdateLives(lives);
        }

        if(lives <= 0)
        {
            GameManager.instance.isGameActive = false;
            _menuManager.ReactivateMenu();
            Destroy(gameObject);
        }
    }
}
