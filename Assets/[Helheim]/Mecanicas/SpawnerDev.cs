using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDev : MonoBehaviour
{
    public GameObject prefab1; // Asigna tu primer prefab aquí en el Inspector
    public GameObject prefab2; // Asigna tu segundo prefab aquí en el Inspector

    void Update()
    {
        // Si se presionan las teclas A y B al mismo tiempo, instancia el prefab1
        if (Input.GetKey(KeyCode.A))
        {
            Instantiate(prefab1, transform.position, Quaternion.identity);
        }

        // Si se presionan las teclas X y Y al mismo tiempo, instancia el prefab2
        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.Y))
        {
            Instantiate(prefab2, transform.position, Quaternion.identity);
        }
    }
    
}
