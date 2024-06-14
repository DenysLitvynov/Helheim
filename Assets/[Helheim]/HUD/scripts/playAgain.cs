using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarLaEscena : MonoBehaviour
{
    // Método para cambiar de escena al hacer clic en el botón
    public void Quit()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("MenuInicial");
        Debug.Log("Cambio de pantalla!");
    }

    public void PlayAgain()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("Main");
        Debug.Log("Cambio de pantalla!");
    }
}
