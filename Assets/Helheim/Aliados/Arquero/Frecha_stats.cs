using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frecha_stats : MonoBehaviour
{
    private bool combate_aliado = false;
    public float vida_Maxima = 50f;//La vida maxima del aliado, solo para comparar y saber si se muere de una vez
    public float vida = 50f; // La vida del aliado
    public float dps = 5f;//da�o que causa el enemigo(el aliado tomara esto como parametro en recibirDa�o())
    private Enemigo_stats enemigo;

    private void Update()
    {
        if (combate_aliado == true)
        {
            // Accede a la variable da�o_boss3 del enemigo
            recibirDano(enemigo.dano_enemigo);
        }
    }


    private void recibirDano(float dano)
    {
        if (combate_aliado == true)
        {
            vida -= dano * Time.deltaTime;
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
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            combate_aliado= false;
        }
    }
}