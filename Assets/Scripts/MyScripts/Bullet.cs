using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

    private float _damage;

    public void Init(float damage, float lifeTime = 0f, string tag = "")
    {
        _damage = damage;
        Destroy(gameObject, lifeTime);
    }

    private void Awake()
    {
        _target = FindObjectOfType<Turrel>().transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, 2f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<ITakeDamage>();
        if (obj != null)
            obj.Hit(_damage);
    }
}
