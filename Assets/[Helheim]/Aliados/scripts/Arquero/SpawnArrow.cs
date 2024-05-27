using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    public GameObject arrowPrefab; // Il prefabbricato della freccia da spawnare
    public float spawnInterval = 3f; // Intervallo di tempo tra uno spawn e l'altro

    private float timer; // Timer per tenere traccia del tempo
    public bool colocado = false;

    void Start()
    {
        // Invoca repetidamente la funzione GenerateArrow ogni spawnInterval secondi, iniziando dopo 1 secondo.
        InvokeRepeating("GenerateArrow", 1.75f, spawnInterval);
    }

    public void GenerateArrow()
    {
        if (colocado)
        {
            // Genera una nuova freccia istanziando il prefab nella posizione e rotazione del generatore
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
            Debug.Log("Freccia generata alla posizione: " + transform.position + " con rotazione: " + transform.rotation);

            // Regola la rotazione dell'oggetto per farlo puntare a destra
            arrow.transform.Rotate(0, 180, 0); // Rotazione di 180 gradi sull'asse Y per farla puntare a destra
            Debug.Log("Freccia ruotata a: " + arrow.transform.rotation);
        }
    }
}

