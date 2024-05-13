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
        _waveSpawner.CheckWaveCompletion(); // Agrega esta línea
        if (gameObject == _waveSpawner._lastEnemy) // Si el enemigo destruido es el último enemigo
        {
            _waveSpawner._lastEnemy = null; // Establece la referencia al último enemigo a null
        }
        if (_waveSpawner._activeEnemies == 0 && _waveSpawner._currentWaveIndex < _waveSpawner._waves.Length - 1 && _waveSpawner._enemiesLeftToSpawn == 0)
        {
            _waveSpawner.LaunchWave(); // Lanza la siguiente ola solo si no estás en la última ola
        }
    }
}