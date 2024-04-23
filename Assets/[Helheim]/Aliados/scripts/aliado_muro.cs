using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aliado_muro : MonoBehaviour
{
    private bool combate_aliado = false;
    public float vida = 100f; // La vida del aliado
    private Enemigo_stats enemigo;

    // Update is called once per frame
    void Update()
    {
        if (combate_aliado == true)
        {
            if (enemigo != null)
            {
                // Accede a la variable del enemigo
                recibirDanyo(enemigo.dano_enemigo);
            }
        }
        // Comprueba si la vida del aliado ha llegado a 0
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye el aliado
        }
    } //(loop)
    private void recibirDanyo(float danyo)
    {
        if (combate_aliado == true)
        {
            vida -= danyo * Time.deltaTime;
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
            combate_aliado = false;
        }
    }
}
