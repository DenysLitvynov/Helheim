using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComportamientoBarra : MonoBehaviour
{

    public UnityEngine.UI.Image vida;

    public float vidaActual = 100f;

    public void restarVida(float dano)
    {

        vidaActual -= dano;


        vida.fillAmount = vidaActual / 100f;


        // Chequear si la vida de la casa llega a 0
        if (vidaActual <= 0f)
        {
            // Detener el juego
            Time.timeScale = 0f;
            SceneManager.LoadScene("PantallaHasPerdido");

            Debug.Log("GameOver");
        }

    }



}