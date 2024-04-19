using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_de_Estados : MonoBehaviour
{
    //========================================================================
    //ESTADOS//
    public Estado_Base_Enemigo estadoActual;//guarda una referencia al estado activo. un maquina de estados solo puede estar en un estado a la vez
    public Estado_combate_enemigo estadoCombate= new Estado_combate_enemigo();
    public Estado_Movimiento_Enemigo estadoMovimiento = new Estado_Movimiento_Enemigo();
    public Estado_muerto_enemigo estadoMuerto = new Estado_muerto_enemigo();
    //========================================================================

    //========================================================================
    //STATS
    public float vida = 100f;
    public float velocidad = 10f;
    public float vidaMaxima;
    public float dano;
    public float dano_Recibido;
    //========================================================================

    void Start() {
    
        estadoMovimiento.velocidad = velocidad;
        estadoCombate.vida = vidaMaxima;
        estadoCombate.vidaMaxima = vidaMaxima;
        estadoCombate.dano_recibido = dano_Recibido;


        //Inicialiamos el primer estado(en cual empieza)
        estadoActual = estadoMovimiento;

        //"this" es una referencia al contexto(this EXACT monobehavour script)
        estadoActual.EnterState(this);
    }

    void Update()
    {
        estadoActual.UpdateState(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        estadoActual.OnCollisionEnter(this,collision);
    }

    public void CambiarEstado(Estado_Base_Enemigo estado)
    {
        estadoActual=estado;
        estadoActual.EnterState(this);
    }

    public void destruir()
    {
        Destroy(gameObject);
    }


}
