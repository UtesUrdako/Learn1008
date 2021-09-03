using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private Rigidbody _rb;

    private float _damage;
    [SerializeField] private float _force = 200f;

    public void Init(float damage, float lifeTime = 0f, string tag = "")
    {
        _damage = damage;
        Destroy(gameObject, lifeTime);
    }

    private void Awake()
    {
        _target = FindObjectOfType<Turrel>().transform;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _target.position, 2f * Time.deltaTime);
        _rb.AddForce(Vector3.forward * _force, ForceMode.Impulse);
        _rb.AddTorque(transform.right * Random.Range(_force / 2f, _force), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<ITakeDamage>();
        if (obj != null)
            obj.Hit(_damage);
    }

    private void OnCollisionEnter(Collision other)
    {
        var obj = other.gameObject.GetComponent<ITakeDamage>();
        if (obj != null)
            obj.Hit(_damage);
    }

    
}
