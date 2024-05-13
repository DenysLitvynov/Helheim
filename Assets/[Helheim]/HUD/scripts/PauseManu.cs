using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManu : MonoBehaviour
{
    public GameObject PausePanel;
    // Start is called before the first frame update

    public string mainMenuSceneName = "MenuInicial"; // Nome della scena del menu principale


    public void Pause(){
        PausePanel.SetActive(true);
        Time.timeScale=0;
    }
    public void Continue(){
        PausePanel.SetActive(false);
        Time.timeScale=1;
    }

    public void GoToMainMenuScene()
    {
        // Carica la scena del menu principale
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
