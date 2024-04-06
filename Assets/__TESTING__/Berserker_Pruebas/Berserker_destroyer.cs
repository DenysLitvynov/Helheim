using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script solo destruye el berserker si para de moverse.
public class Berserker_destroyer : MonoBehaviour
{
    public float tolerancia = 0.01f; // Tolerancia para detectar si el objeto se ha movido
    private Vector3? posicionAnterior = null; // Inicializar a null
    private Movimiento_Aliodos sera_destruido;

    void Start()
    {
        sera_destruido = GetComponent<Movimiento_Aliodos>();
    }

    void Update()
    {
        if (posicionAnterior != null && Vector3.Distance(transform.position, posicionAnterior.Value) <= tolerancia && sera_destruido.esta_en_combate == false)
        {
            // El objeto ha dejado de moverse, destruirlo
            Destroy(gameObject);
        }
        else
        {
            // El objeto se está moviendo, actualizar la posición anterior
            posicionAnterior = transform.position;
        }
    }
}


