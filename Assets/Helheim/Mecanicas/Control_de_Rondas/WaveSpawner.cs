using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Waves[] _waves;
    private int _currentEnemyIndex;
    public int _currentWaveIndex; // Inicializa a 0
    private int _enemiesLeftToSpawn;
    public int _activeEnemies; // Nuevo contador
    public GameObject _lastEnemy; // Referencia al ъltimo enemigo

    private void Start()
    {
        LaunchWave();
    }

    private IEnumerator SpawnEnemyInWave()
    {
        if (_enemiesLeftToSpawn > 0)
        {
            yield return new WaitForSeconds(_waves[_currentWaveIndex]
                .WaveSettings[_currentEnemyIndex]
                .SpawnDelay);
            _lastEnemy = Instantiate(_waves[_currentWaveIndex]
                .WaveSettings[_currentEnemyIndex].Enemy,
                _waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex]
                .NeededSpawner.transform.position, Quaternion.identity);
            _enemiesLeftToSpawn--;
            _currentEnemyIndex++;
            _activeEnemies++; // Incrementa el contador cuando se genera un enemigo

            StartCoroutine(SpawnEnemyInWave());
        }
    }

    public void LaunchWave()
    {
        if (_activeEnemies == 0 && _currentWaveIndex < _waves.Length) // Solo lanza la siguiente ola si no hay enemigos activos
        {
            _enemiesLeftToSpawn = _waves[_currentWaveIndex].WaveSettings.Length;
            _currentEnemyIndex = 0;
            if (this != null)
            {
                StartCoroutine(SpawnEnemyInWave());
            }
            if (_currentWaveIndex < _waves.Length - 1) // Solo incrementa si no estamos en la última ola
            {
                _currentWaveIndex++;
            }
        }
    }

    // Método para incrementar el contador de enemigos activos
    public void IncrementActiveEnemies()
    {
        _activeEnemies++;
    }
}



[System.Serializable]
public class Waves
{
    [SerializeField] private WaveSettings[] _waveSettings;
    public WaveSettings[] WaveSettings { get => _waveSettings; }
}

[System.Serializable]
public class WaveSettings
{
    [SerializeField] private GameObject _enemy;
    public GameObject Enemy { get => _enemy; }
    [SerializeField] private GameObject _neededSpawner;
    public GameObject NeededSpawner { get => _neededSpawner; }
    [SerializeField] private float _spawnDelay;
    public float SpawnDelay { get => _spawnDelay; }
}
