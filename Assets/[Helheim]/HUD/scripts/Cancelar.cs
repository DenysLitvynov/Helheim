using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Cancelar : MonoBehaviour
{
    public GameObject PausePanel;
    // Start is called before the first frame update

    public string mainMenuSceneName = "MenuInicial"; // Nome della scena del menu principale


    public void Pause(){
        PausePanel.SetActive(true);
        
    }
    public void Continue(){
        PausePanel.SetActive(false);
        
    }

    public void GoToMainMenuScene()
    {
        // Carica la scena del menu principale
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
