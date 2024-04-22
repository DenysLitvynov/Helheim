using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarPantalla : MonoBehaviour
{
    // Start is called before the first frame update
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Opciones()
    {
         Debug.Log("Fuera de servicio...");
    }

    // Update is called once per frame
    public void Salir()
    {
        Debug.Log("Salir...");
         
    }
}
