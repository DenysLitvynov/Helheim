using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espectro_Stats : MonoBehaviour
{
    private Movimiento_Enemigo combate;
    public float vida_maxima = 100f;//La vida maxima del enemigo, solo para comparar y saber si se muere de una vez
    public float vida = 100f; // La vida del enemigo
    public float daсo_espectro = 50f;//daсo que causa el enemigo(el aliado tomara esto como parametro en recibirDaсo())
    private Aliado_stats aliado;
    private aliado_muro muro;
    private void Start()
    {
        combate = GetComponent<Movimiento_Enemigo>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            // Obtiene una referencia al objeto del aliado
            aliado = collision.gameObject.GetComponent<Aliado_stats>();
            muro = collision.gameObject.GetComponent<aliado_muro>();
            if (aliado != null )
            {
                // Hace daño al aliado
                aliado.vida -= daсo_espectro; // Elimina la multiplicación por Time.deltaTime
                // Destruye el espectro
                Destroy(gameObject);
            }else if(muro != null){
                 // Hace daño al aliado
                muro.vida -= daсo_espectro; // Elimina la multiplicación por Time.deltaTime
                // Destruye el espectro
                Destroy(gameObject);
            }
        }
    }
}