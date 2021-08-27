using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private Animator _animator;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnBullet;
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _anim;

    public float speed;
    public float speedRotate;
    public float jumpForce;

    private bool _isForse;
    private bool _isDie;
    private Vector3 _direction;

    private void Awake()
    {
        _isDie = false;
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {

        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _isForse = Input.GetButton("Forse");

        if (_direction == Vector3.zero)
        {
            _anim.SetBool("IsMove", false);

            if (Input.GetMouseButtonDown(0))
                _anim.SetTrigger("Shoot");
        }
        else
            _anim.SetBool("IsMove", true);

        if (Input.GetKeyDown(KeyCode.L))
            _anim.SetTrigger("Die");

    }

    private void FixedUpdate()
    {
        Move();

        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * speedRotate, 0);
    }

    private void Move()
    {
        float s = (_isForse) ? speed * 2f : speed;

        transform.Translate(_direction.normalized * s * Time.fixedDeltaTime);
    }

    private void Fire()
    {

        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().Init(10f, 30f);

        _isDie = false;
    }

    private void Die()
    {
        _isDie = true;
    }    

    public void Jump(int force)
    {
        _rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
