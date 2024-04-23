using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_Frecha : MonoBehaviour
{
    public float velocita = 5f; // Velocità di movimento
    public Vector3 direzione = Vector3.forward; // Direzione di movimento
    //private bool combate_aliado = false;
    public float dps = 40f;
    public float delay = 4f; // Tempo di ritardo prima della cancellazione

    void Start()
    {
        // Avvia la funzione di cancellazione dopo il ritardo specificato
        Invoke("DeleteObject", delay);
    }

    
    void Update()
    {
        // Calcola il vettore di spostamento moltiplicando la direzione per la velocità e il tempo trascorso dall'ultimo frame
        Vector3 spostamento = direzione * velocita * Time.deltaTime;

        // Applica lo spostamento al GameObject
        transform.Translate(spostamento);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Entorno")
        {
            Destroy(gameObject);
        }
       
    }
    void DeleteObject()
    {
        // Cancella l'oggetto
        Destroy(gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(gameObject);        
         }
    }
}
