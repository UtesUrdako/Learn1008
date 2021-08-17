using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private Player _player;
    [SerializeField] private float _hp = 100f;

    public void Hit(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
