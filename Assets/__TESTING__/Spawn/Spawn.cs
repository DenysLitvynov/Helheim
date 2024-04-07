using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawn : MonoBehaviour
{
    public GameObject cubePrefab; // Il prefabbricato del cubo da spawnare
    public float spawnInterval = 5f; // Intervallo di tempo tra uno spawn e l'altro

    private float timer; // Timer per tenere traccia del tempo

    void Start()
    {
        // Inizializza il timer
        timer = spawnInterval;
    }

    void Update()
    {
        // Aggiorna il timer
        timer -= Time.deltaTime;

        // Se il timer è inferiore o uguale a zero, spawniamo un cubo e riavviamo il timer
        if (timer <= 0f)
        {
            SpawnFrecha();
            timer = spawnInterval;
        }
    }

    void SpawnFrecha()
    {
        // Genera un nuovo cubo istanziando il prefabbricato nella posizione del generatore
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
