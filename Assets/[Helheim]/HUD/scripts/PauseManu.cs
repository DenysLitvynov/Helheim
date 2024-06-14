using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManu : MonoBehaviour
{
    public GameObject PausePanel;
    // Nombre de la escena del menú principal
    public string mainMenuSceneName = "MenuInicial";

    // Método para pausar el juego
    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Método para continuar el juego
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Método para ir al menú principal
    public void GoToMainMenuScene()
    {
        // Restablece el timeScale a 1 antes de cambiar de escena
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // Método para volver a jugar (recargar la escena actual)
    public void PlayAgain()
    {
        // Restablece el timeScale a 1 antes de recargar la escena
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

