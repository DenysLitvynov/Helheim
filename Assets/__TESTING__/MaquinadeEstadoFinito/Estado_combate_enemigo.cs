using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Estado_combate_enemigo : Estado_Base_Enemigo
{
    

    public float vida;
    public float vidaMaxima;
    public float dano_recibido;
    private bool enCombate;

    //COSAS DE ALIADOS
    private Aliado_stats aliado;
    private Movimento_Frecha frecha;

    public override void EnterState(Controlador_de_Estados enemigo)
    {
        Debug.Log("HOLA DESDE EL ESTADO COMBATE");
    }

    public override void UpdateState(Controlador_de_Estados enemigo)
    {
        if (aliado == null)
        {
            enemigo.CambiarEstado(enemigo.estadoMovimiento);
        }
        else
        {
            dano_recibido = aliado.dps;
            vida -= dano_recibido * Time.deltaTime;
            //Debug.Log("DAÑO RECIBIDO : " + dano_recibido);

            if (vida <= 0 || dano_recibido >= vidaMaxima)
            {
                enemigo.CambiarEstado(enemigo.estadoMuerto);
            }
        }
    }




    public override void OnCollisionEnter(Controlador_de_Estados enemigo, Collision collision)
    {
        if (collision.gameObject.CompareTag("Aliado"))
        {
            frecha = collision.gameObject.GetComponent<Movimento_Frecha>();
            // Obtiene una referencia al objeto del aliado
            aliado = collision.gameObject.GetComponent<Aliado_stats>();
        }
    }

}


