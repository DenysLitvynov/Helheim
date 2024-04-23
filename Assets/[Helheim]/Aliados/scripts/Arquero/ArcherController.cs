/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArcherController : MonoBehaviour
{
    // Raggio di visione dell'arciere
    public float visionRange = 10f;

    // Tempo di ricarica per il prossimo attacco
    public float attackCooldown = 2f;

    // Prefab del proiettile
    public GameObject arrowPrefab;

    // Posizione da cui sparare il proiettile
    public Transform arrowSpawnPoint;

    // Tag degli enemigo
    public string enemyTag = "enemigo";

    // Variabile per tenere traccia del tempo trascorso dall'ultimo attacco
    private float attackTimer = 0f;

    public SpawnArrow arrowSpawner; 

    void Update()
    {
        // Controlla se è il momento di attaccare
        if (Time.time >= attackTimer)
        {
            // Ottieni tutti gli oggetti con il tag "enemigo" all'interno del raggio di visione dell'arciere
            Collider[] enemies = Physics.OverlapSphere(transform.position, visionRange);
            
            // Itera attraverso gli enemigo trovati
            foreach (Collider enemy in enemies)
            {
                if (enemy.CompareTag(enemyTag))
                {
                    // Spara al nemico
                    Shoot(enemy.transform);
                    
                    // Imposta il timer per il prossimo attacco
                    attackTimer = Time.time + attackCooldown;
                    
                    // Esci dal ciclo foreach
                    break;
                }
            }
        }
    }
    void Shoot(Transform target)
{
    // Controlla se l'arrowSpawner è stato assegnato
    if (arrowSpawner != null)
    {
        // Spara una freccia utilizzando la classe SpawnArrow
        arrowSpawner.GenerateArrow();
    }
    else
    {
        Debug.LogError("Arrow spawner not assigned!");
    }
}
}*/