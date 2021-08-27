using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WayPoint
{
    public Transform[] _enemyWayPoint;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _enemyCount;
    [SerializeField] private WayPoint[] _enemyWayPoint;

    private List<Enemy> _enemyPool;

    // Start is called before the first frame update
    void Awake()
    {
        _enemyPool = new List<Enemy>();
        StartCoroutine(Spawn());

        GameObject.Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        GameObject.Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        GameObject.Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var e in _enemyPool)
            if (!e.gameObject.activeSelf)
            {
                e.gameObject.SetActive(true);
                e.RestartParameters();
                e.transform.position = transform.position;
            }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            if (_enemyPool.Count - 1 < _enemyCount)
            {
                GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                _enemyPool.Add(enemy.GetComponent<Enemy>());
            }
        }
    }
}
