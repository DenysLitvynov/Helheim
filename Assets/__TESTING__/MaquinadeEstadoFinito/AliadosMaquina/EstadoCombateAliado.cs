using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoCombateAliado : Estado_Base_ALIADO
{
    public float vida_Maxima;//La vida maxima del aliado, solo para comparar y saber si se muere de una vez
    public float vida; // La vida del aliado

    private Controlador_de_Estados enemigo;
    private Espectro_Stats espectro;

    public override void EnterState(Controlador_De_Estados_ALIADOS aliado)
    {
        vida = vida_Maxima;
    }

    public override void UpdateState(Controlador_De_Estados_ALIADOS aliado)
    {

        if (enemigo == null)
        {
            aliado.CambiarEstado(aliado.estadoMovimiento);
        }
        else
        {
            {
                recibirDano(aliado, enemigo.dano);
            }
        }
    }

    public override void OnCollisionEnter(Controlador_De_Estados_ALIADOS aliado, Collision collision)
    {
        // Obtiene una referencia al script Espectro_Stats en el objeto de la colisión
         espectro = collision.gameObject.GetComponent<Espectro_Stats>();

        if (espectro != null) // Si el objeto tiene el script Espectro_Stats
        {
            recibirDano(aliado, espectro.daсo_espectro);
        }
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Obtiene una referencia al objeto del enemigo
            enemigo = collision.gameObject.GetComponent<Controlador_de_Estados>();
        }
    }

    public void recibirDano(Controlador_De_Estados_ALIADOS aliado, float dano_recibido)
    {
        vida -= dano_recibido * Time.deltaTime;
        //Debug.Log("Dano : " + dano_recibido);
        if (vida <= 0 || dano_recibido >= vida_Maxima)
        {
            aliado.destruir();
        }
    }
}

