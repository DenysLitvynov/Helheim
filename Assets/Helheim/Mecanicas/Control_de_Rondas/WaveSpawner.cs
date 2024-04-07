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
    public GameObject _lastEnemy; // Referencia al último enemigo

    private bool _firstWaveLaunched = false;

    private void Start()
    {
        LaunchWave();
    }

    private IEnumerator SpawnEnemyInWave()
    {
        if (_enemiesLeftToSpawn > 0 && _currentEnemyIndex < _waves[_currentWaveIndex].WaveSettings.Length)
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
        else
        {
            CheckWaveCompletion(); // Verifica si la ola actual ha sido completada
        }
    }

    public void LaunchWave()
    {
        if (!_firstWaveLaunched)
        {
            _firstWaveLaunched = true;
        }
        else
        {
            // Verifica si estamos en la última ronda antes de incrementar _currentWaveIndex
            if (_currentWaveIndex < _waves.Length - 1)
            {
                _currentWaveIndex++; // Incrementa la ronda solo si no es la última
            }
        }

        if (_currentWaveIndex < _waves.Length) // Lanza la siguiente ola si hay olas disponibles
        {
            _enemiesLeftToSpawn = _waves[_currentWaveIndex].WaveSettings.Length;
            _currentEnemyIndex = 0;
            if (this != null) // Verifica si el objeto WaveSpawner todavía existe
            {
                StartCoroutine(SpawnEnemyInWave());
            }
        }
    }

    private void CheckWaveCompletion()
    {
        if (_activeEnemies == 0 && _currentWaveIndex < _waves.Length - 1 && !_waves[_currentWaveIndex].IsCompleted) // Solo incrementa si no estamos en la última ola, no hay enemigos activos y la ronda actual no está completada
        {
            _waves[_currentWaveIndex].IsCompleted = true; // Marca la ronda como completada
            LaunchWave(); // Lanza la siguiente ola
        }
        else if (_activeEnemies == 0 && _currentWaveIndex == _waves.Length - 1) // Si estamos en la última ola y todos los enemigos han sido destruidos
        {
            // Detener el juego
            Time.timeScale = 0f;
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
    public bool IsCompleted;
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
