using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliado_stats : MonoBehaviour
{
    private bool combate_aliado = false;
    public float vida_Maxima = 50f;//La vida maxima del aliado, solo para comparar y saber si se muere de una vez
    public float vida = 50f; // La vida del aliado
    public float dps = 5f;//daсo que causa el enemigo(el aliado tomara esto como parametro en recibirDaсo())
    private Enemigo_stats enemigo;
    private Espectro_Stats espectro;

    private void Update()
    {
        if (combate_aliado == true)
        {
            // Check if the enemy is an Espectro
            if (espectro != null)
            {
                // Accede a la variable de daño del espectro
                recibirDaсo(espectro.daсo_espectro);
            }
            else if (enemigo != null)
            {
                // Accede a la variable daсo_boss3 del enemigo
                recibirDaсo(enemigo.daсo_enemigo);
            }
        }
    }

    private void recibirDaсo(float daсo)
    {
        if (combate_aliado == true)
        {
            vida -= daсo * Time.deltaTime;
        }
        // Comprueba si la vida del aliado ha llegado a 0
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye el aliado
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            combate_aliado = true;
            // Obtiene una referencia al objeto del aliado
            enemigo = collision.gameObject.GetComponent<Enemigo_stats>();
            espectro = collision.gameObject.GetComponent<Espectro_Stats>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            combate_aliado = false;
        }
    }
}