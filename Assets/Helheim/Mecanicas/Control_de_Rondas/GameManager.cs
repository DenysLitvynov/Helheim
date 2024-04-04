using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton para acceder al GameManager desde cualquier parte del código
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Establecer el singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Método para detener el juego cuando la vida de la casa llega a 0
    public void GameOver()
    {
        // Aquí puedes agregar la lógica para mostrar un mensaje de "Game Over" o realizar otras acciones
        Debug.Log("Game Over");
        Time.timeScale = 0f; // Detener el tiempo del juego
    }
}
