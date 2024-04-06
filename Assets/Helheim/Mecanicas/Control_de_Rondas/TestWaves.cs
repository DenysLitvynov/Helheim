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
        _waveSpawner._activeEnemies--; // Decrementa el contador cuando se destruye un enemigo
        if (gameObject == _waveSpawner._lastEnemy) // Si el enemigo destruido es el �ltimo enemigo
        {
            _waveSpawner._lastEnemy = null; // Establece la referencia al �ltimo enemigo a null
        }
        if (_waveSpawner._activeEnemies == 0)
            _waveSpawner.LaunchWave();
    }
}

