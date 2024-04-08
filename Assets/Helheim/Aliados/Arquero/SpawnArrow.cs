using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    public GameObject arrowPrefab; // Il prefabbricato della freccia da spawnare
    public float spawnInterval = 3f; // Intervallo di tempo tra uno spawn e l'altro

    private float timer; // Timer per tenere traccia del tempo
    public bool colocado=false;

    void Start()
    {
        // Invoca repetidamente la función GenerateArrow cada 4 segundos, comenzando después de 0 segundos.
        InvokeRepeating("GenerateArrow", 1f, spawnInterval);
    }


    public void GenerateArrow()
    {
        if(colocado){
            // Genera una nuova freccia istanziando il prefabbricato nella posizione del generatore
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
             // Ajusta la rotación del objeto para que apunte hacia la derecha
            arrow.transform.Rotate(0, -180, 0); // Rotación de -90 grados sobre el eje Z para que apunte hacia la derecha
        }
        
    }
    
}
