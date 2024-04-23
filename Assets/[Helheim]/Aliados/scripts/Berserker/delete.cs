using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour

{
    public int tiempoEnMilisegundos = 5000;

    // Start is called before the first frame update
    void Start()
    {
        // Destruir el objeto después de 5 segundos
        Destroy(gameObject, tiempoEnMilisegundos / 1000f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
