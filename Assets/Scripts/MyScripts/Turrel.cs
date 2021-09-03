using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour, ITakeDamage
{
    private Transform _target;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private ParticleSystem _particle;

    [SerializeField] private Transform _head;
    [SerializeField] private float _speed = 1f;
    public float angle;
    [SerializeField] private float _hp = 100f;
    [SerializeField] private float _timeReload = 2f;
    private bool _isFire;
    [SerializeField] private int _countBullet = 10;

    public void Hit(float damage)
    {
        _hp -= damage / 2f;
        _particle.Play();
        if (_hp <= 0)
            Destroy(gameObject);
    }

    private void Awake()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        _target = FindObjectOfType<Player>().transform;

        StartCoroutine(Reload(_timeReload));
    }
    float needAngle = 0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 upPoint = new Vector3(_target.position.x, _head.position.y, _target.position.z);
        Vector3 dir = (upPoint - _head.position);
        Vector3 stepDir = Vector3.RotateTowards(_head.forward, dir, _speed * Time.deltaTime, 0f);
        angle = Vector3.Angle(_head.forward, dir);

        if (Physics.Raycast(_spawnBullet.position + Vector3.up * 1.5f, _spawnBullet.forward, out RaycastHit hit, 20f, LayerMask.NameToLayer("UI"), QueryTriggerInteraction.Ignore))
        {
            Debug.DrawLine(_spawnBullet.position, hit.point, Color.green, Time.deltaTime);
            if (hit.collider.tag == "Player" && _isFire)
                Fire();
        }
        else
        {
            Debug.DrawLine(_spawnBullet.position, _spawnBullet.forward * 20f, Color.blue, Time.deltaTime);
        }

        _head.rotation = Quaternion.LookRotation(stepDir);

        if (angle < 40f)
        {
            float step = Time.deltaTime * _speed;
            _head.Rotate(Vector3.up * step);
            angle += step;
        }
        
    }

    private IEnumerator Reload(float timeReload)
    {
        yield return new WaitForSeconds(5f);
        while (_countBullet > 0)
        {
            _countBullet--;
            _isFire = true;

            yield return AnyCoroutine();
        }
    }

    private IEnumerator AnyCoroutine()
    {
        for (int i = 0; i < 10; i++)
            yield return new WaitForSeconds(0.1f);
    }

    private void Fire()
    {
        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().Init(10f, 30f);

        _isFire = false;
    }


}
