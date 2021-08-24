using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private Player _player;
    [SerializeField] private float _hp = 100f;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _wayPoint;

    public void Hit(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            gameObject.SetActive(false);
    }

    public void RestartParameters()
    {

    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //_player = GameObject.FindObjectOfType<Player>();

        _agent.SetDestination(_wayPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (NavMesh.SamplePosition(_agent.transform.position, out NavMeshHit navMeshHit, 0.2f, NavMesh.AllAreas))
            print(NavMesh.GetAreaCost((int)Mathf.Log(navMeshHit.mask, 2)));
    }
}
