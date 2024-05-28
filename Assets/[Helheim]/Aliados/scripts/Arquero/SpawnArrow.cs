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
            // Genera una nueva flecha instanciando el prefab en la posición del generador
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);

            // Asegúrate de que la flecha se dispare en la dirección X del objeto SpawnArrow
            Vector3 direction = transform.right; // Esto obtiene la dirección X del objeto SpawnArrow
            arrow.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

}
