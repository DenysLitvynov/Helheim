using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Waves[] _waves;
    private int _currentEnemyIndex;
    public int _currentWaveIndex = 0; // Inicializa a 0
    private int _enemiesLeftToSpawn;
    public int _activeEnemies; // Nuevo contador
    public GameObject _lastEnemy; // Referencia al �ltimo enemigo

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
        }
        // Mueve esta l�nea fuera del condicional
        StartCoroutine(SpawnEnemyInWave());
    }

    public void LaunchWave()
    {
        if (_activeEnemies == 0 && _lastEnemy == null && _currentWaveIndex < _waves.Length - 1) // Solo lanza la siguiente ola si no hay enemigos activos y el �ltimo enemigo est� destruido
        {
            _currentWaveIndex++;
            _enemiesLeftToSpawn = _waves[_currentWaveIndex].WaveSettings.Length;
            _currentEnemyIndex = 0;
            StartCoroutine(SpawnEnemyInWave());
        }
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
