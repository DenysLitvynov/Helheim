using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    public GameObject arrowPrefab; // Il prefabbricato della freccia da spawnare
    public float spawnInterval = 3f; // Intervallo di tempo tra uno spawn e l'altro

    private float timer; // Timer per tenere traccia del tempo
    private bool arrowGenerated = true; // Flag per indicare se una freccia è già stata generata

    void Start()
    {
        // Invoca repetidamente la función GenerateArrow cada 4 segundos, comenzando después de 0 segundos.
        InvokeRepeating("GenerateArrow", 1f, spawnInterval);
    }


    public void GenerateArrow()
    {
        // Genera una nuova freccia istanziando il prefabbricato nella posizione del generatore
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
    }
    
}
