using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    public GameObject arrowPrefab; // Il prefabbricato della freccia da spawnare

  
    public bool colocado = false;

    void Start()
    {
        // Invoca repetidamente la funzione GenerateArrow ogni spawnInterval secondi, iniziando dopo 1 secondo.
       // InvokeRepeating("GenerateArrow", 1.75f, spawnInterval);
    }

    public void GenerateArrow()
    {
        if (colocado)
        {
            // Genera una nueva flecha instanciando el prefab en la posici�n del generador
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0,0,0));

            // Aseg�rate de que la flecha se dispare en la direcci�n X del objeto SpawnArrow
            //Vector3 direction = transform.right; // Esto obtiene la direcci�n X del objeto SpawnArrow
            //arrow.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

}
