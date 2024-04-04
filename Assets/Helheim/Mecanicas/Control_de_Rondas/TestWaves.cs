using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWaves : MonoBehaviour
{
    private WaveSpawner _waveSpawner;

    private void Awake()
    {
        _waveSpawner = GameObject.Find("Wave Controller").GetComponent<WaveSpawner>();
    }

    private void OnDestroy()
    {
        int enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft == 0)
            _waveSpawner.LaunchWave();
    }
}
