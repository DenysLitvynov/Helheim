using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espectro_Stats : MonoBehaviour
{
    private Movimiento_Enemigo combate;
    public float vida_maxima = 100f;//La vida maxima del enemigo, solo para comparar y saber si se muere de una vez
    public float vida = 100f; // La vida del enemigo
    public float daсo_espectro = 15f;//daсo que causa el enemigo(el aliado tomara esto como parametro en recibirDaсo())
    private Aliado_stats aliado;

    private void Start()
    {
        combate = GetComponent<Movimiento_Enemigo>();
    }

    private void Update()
    {
        if (combate.esta_en_combate == true)
        {
            // Accede a la variable dps del aliado
            recibirDaсo(aliado.dps);
        }
    }

    private void recibirDaсo(float daсo)
    {
        if (combate.esta_en_combate == true)
        {
            vida -= daсo * Time.deltaTime;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (vida <= 0 || daсo > vida_maxima)
        {
            Destroy(gameObject); // Destruye el enemigo
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            combate.esta_en_combate = true;
            // Obtiene una referencia al objeto del aliado
            aliado = collision.gameObject.GetComponent<Aliado_stats>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            combate.esta_en_combate = false;
        }
    }
}