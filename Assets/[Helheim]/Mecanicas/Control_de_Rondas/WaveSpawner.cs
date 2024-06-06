using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] public Waves[] _waves;
    private int _currentEnemyIndex;
    public int _currentWaveIndex; // Inicializa a 0
    public int _enemiesLeftToSpawn;
    public int _activeEnemies; // Nuevo contador
    public GameObject _lastEnemy; // Referencia al último enemigo

    private bool _firstWaveLaunched = false;

    private void Start()
    {
        LaunchWave();
    }

    private IEnumerator SpawnEnemyInWave()
    {
        while (_enemiesLeftToSpawn > 0 && _currentWaveIndex < _waves.Length && _currentEnemyIndex < _waves[_currentWaveIndex].WaveSettings.Length)
        {
            WaveSettings currentWaveSetting = _waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex];
            if (currentWaveSetting != null && currentWaveSetting.NeededSpawner != null)
            {
                yield return new WaitForSeconds(currentWaveSetting.SpawnDelay);

                if (currentWaveSetting.Enemy != null)
                {
                    _lastEnemy = Instantiate(currentWaveSetting.Enemy, currentWaveSetting.NeededSpawner.transform.position, Quaternion.identity);
                    _activeEnemies++;
                    _enemiesLeftToSpawn--;
                    _currentEnemyIndex++;
                }
                else
                {
                    Debug.LogWarning("Enemy prefab is null. Skipping this enemy.");
                    _enemiesLeftToSpawn--;
                    _currentEnemyIndex++;
                }
            }
            else
            {
                Debug.LogWarning("WaveSettings or NeededSpawner is null. Skipping this enemy.");
                _enemiesLeftToSpawn--;
                _currentEnemyIndex++;
            }
        }

        CheckWaveCompletion();
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

    public void CheckWaveCompletion()
    {
        Debug.Log("CheckWaveCompletion called. _enemiesLeftToSpawn: " + _enemiesLeftToSpawn + ", _activeEnemies: " + _activeEnemies); // Agrega esta línea
        // Solo cambia de ronda si no quedan enemigos por generar y no hay enemigos activos
        if (_enemiesLeftToSpawn == 0 && _activeEnemies == 0)
        {
            if (_currentWaveIndex < _waves.Length - 1)
            {
                LaunchWave(); // Lanza la siguiente ola
            }
            else if (_currentWaveIndex == _waves.Length - 1) // Si estamos en la última ola
            {
                Debug.Log("HAS GANADO");
                SceneManager.LoadScene("PantallaHasGanado");
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
