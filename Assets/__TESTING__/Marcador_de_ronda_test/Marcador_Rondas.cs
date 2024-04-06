using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Marcador_Rondas : MonoBehaviour
{
    public Text Contador_Rondas;
    private WaveSpawner contador;

    private void Start()
    {
        // Asigna a 'contador' el componente WaveSpawner del objeto correspondiente
        contador = GameObject.FindObjectOfType<WaveSpawner>();

        // Muestra el número de la ronda actual sin sumar 1
        Contador_Rondas.text = "Ronda " + (contador._currentWaveIndex + 1).ToString() + "/5";
    }

    // Update is called once per frame
    void Update()
    {
        // Mantiene la lógica consistente, no suma 1 a _currentWaveIndex en el contador
        Contador_Rondas.text = "Ronda " + (contador._currentWaveIndex).ToString() + "/5";
    }
}
