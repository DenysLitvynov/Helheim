using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambiarLaEscena : MonoBehaviour
{
    // M�todo para cambiar de escena al hacer clic en el bot�n
    public void OnClickHandler()
    {
            SceneManager.LoadScene("EscenaFinal");

        Debug.Log("Cambio de pantalla!");

        }
       
   
}