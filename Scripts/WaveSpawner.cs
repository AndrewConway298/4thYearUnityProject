using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    //Setting State of Level
    public enum SpawnState { EnemiesSpawning, Waiting, CountingDown};

	[System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    //Makes array if waves
    public Wave[] waves;
    public int nextWave = 0;

    //Wave Control
    public float waveTimer = 5.0f;
    public float waveCountdown;

    //Enemy Control
    private float searchCountdown = 1.0f;

    private SpawnState state = SpawnState.CountingDown;

    void Start()
    {
        waveCountdown = waveTimer;
    }

    //Wave Spawning Manager
    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!isEnemyAlive())
            {
                NextWave();
            }
            else
            {
                return;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.EnemiesSpawning)
            {
                
                StartCoroutine( WaveSpawn (waves[nextWave]) );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void NextWave()
    {
        Debug.Log("Wave Complete");
        state = SpawnState.CountingDown;
        waveCountdown = waveTimer;

        //Winning/Error Handling
        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }

    }

    //Checks for enemies
    bool isEnemyAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator WaveSpawn(Wave _wave)
    {
        Debug.Log(_wave.name);
        state = SpawnState.EnemiesSpawning;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.Waiting;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy");
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}
