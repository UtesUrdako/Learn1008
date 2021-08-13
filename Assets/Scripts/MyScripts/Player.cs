using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private Animator _animator;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnBullet;

    public float speed;

    private bool _isForse;
    private bool _isFire;
    private Vector3 _direction;

    private void Awake()
    {
        _isFire = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _isFire = true;

        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _isForse = Input.GetButton("Forse");
    }

    private void FixedUpdate()
    {
        if (_isFire)
            Fire();

        Move();
    }

    private void Move()
    {
        float s = (_isForse) ? speed * 2f : speed;

        transform.Translate(_direction.normalized * s * Time.fixedDeltaTime);
    }

    private void Fire()
    {
        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().Init(3f);

        _isFire = false;
    }
}
