using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambiarLaEscena : MonoBehaviour
{
    // Método para cambiar de escena al hacer clic en el botón
    public void OnClickHandler()
    {
            SceneManager.LoadScene("EscenaFinal");

        Debug.Log("Cambio de pantalla!");

        }
       
   
}