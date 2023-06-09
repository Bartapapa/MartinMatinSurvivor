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

    [Header("List of Enemies")]
    public List<Enemy> Enemies = new List<Enemy>();

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
        
        float timeScale = Time.time*.05f;
        _timeToNextSpawn = BaseTimeBetweenSpawn + (Random.Range(-MaxSpawnVariance, MaxSpawnVariance)-timeScale);
    }

    private void Spawn()
    {
        int randomIntSpawn = Random.Range(0, Spawners.Count);
        int randomIntEnemy = Random.Range(0, Enemies.Count);


        Enemy newEnemy = Instantiate<Enemy>(Enemies[randomIntEnemy], Spawners[randomIntSpawn].position, Quaternion.identity);
        newEnemy.InitializeEnemy(DebugTarget, Random.Range(2f,5f));
    }
}
