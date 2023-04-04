using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Time between spawn")]
    public float BaseTimeBetweenSpawn = 5f;
    public float MaxSpawnVariance = 2f;
    private float _timeToNextSpawn = 0f;

    [Header("List of spawn")]
    public List<Transform> Spawners = new List<Transform>();

    [Header("DEBUG-testEnemy")]
    public Enemy Enemy;
    public Transform DebugTarget;

    private void Start()
    {
        GetNextTimeSpawn();
    }
    void Update()
    {
        if (_timeToNextSpawn > 0)
        {
            _timeToNextSpawn -= Time.deltaTime;
        }
        else
        {
            Spawn();
            GetNextTimeSpawn();
        }
    }

    private void GetNextTimeSpawn()
    {
        _timeToNextSpawn = BaseTimeBetweenSpawn + (Random.Range(-MaxSpawnVariance, MaxSpawnVariance));
    }

    private void Spawn()
    {
        int randomInt = Random.Range(0, Spawners.Count);
        Enemy newEnemy = Instantiate<Enemy>(Enemy, Spawners[randomInt].position, Quaternion.identity);
        newEnemy.InitializeEnemy(DebugTarget, 5f);
    }
}
