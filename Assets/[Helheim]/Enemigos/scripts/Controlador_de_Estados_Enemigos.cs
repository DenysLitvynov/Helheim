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
    public float velocidad = 10f;
    public float vidaMaxima = 100f;
    public float dano;

    //DROPS
    public CharacterCardScriptableObject martillo;
    public CharacterCardScriptableObject berserk;
    //========================================================================

    void Start() {
        //ASIGNACIONES ESTADO MOVIMIENTO
        int numeroAleatorio = UnityEngine.Random.Range(1, 9);
        estadoMovimiento.velocidad = velocidad;
        estadoMovimiento.filaSelecionada = numeroAleatorio;

        //ASIGNACIONES ESTADO COMBATE
        estadoCombate.vidaMaxima = vidaMaxima;

        //ASIGNACION PARA ESTADO MUERTO(PARA CONTROLAR EL DROPEO DE CARTAS)
          estadoMuerto.berserk = berserk;
          estadoMuerto.martillo = martillo;

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
