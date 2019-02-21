using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _fireRate = 0.25f;

    [SerializeField]
    private float _canFire;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _trippleshotPrefab;

    private float _horizontalInput;
    private float _verticalInput;

    
    public bool _isLaserUpgraded;

    private Vector3 movementVector = new Vector3(1, 1, 0);
	// Use this for initialization
	void Start () {
        Debug.Log(movementVector);
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
       
        if(_isLaserUpgraded)
        {
            Instantiate(_trippleshotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
        }
            _canFire = Time.time + _fireRate;
            
    }

    public void TrippleShotPowerUpOn()
    {
        _isLaserUpgraded = true;
        StartCoroutine(ShutDownPowerUpOn());
    }

    public IEnumerator ShutDownPowerUpOn()
    {
        yield return new WaitForSeconds(10);
        _isLaserUpgraded = false;
    }

    private void Movemevt()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        movementVector.x = _horizontalInput * 1;
        movementVector.y = _verticalInput * 1;

        Debug.Log(movementVector.x);

        transform.Translate(movementVector * _speed * Time.deltaTime);
        //   transform.Translate(movementVector * speed * horizontalInput * verticalInput * Time.deltaTime);
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

    
}
