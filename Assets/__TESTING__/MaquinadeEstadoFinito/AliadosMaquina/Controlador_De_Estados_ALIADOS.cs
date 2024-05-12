using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_De_Estados_ALIADOS : MonoBehaviour
{
    //========================================================================
    //ESTADOS//
    public Estado_Base_ALIADO estadoActual;//guarda una referencia al estado activo. un maquina de estados solo puede estar en un estado a la vez
    public EstadoCombateAliado estadoCombate = new EstadoCombateAliado();
    public EstadoMuertoAliado estadoMuerto = new EstadoMuertoAliado();
    public EstadoMovimientoAliado estadoMovimiento= new EstadoMovimientoAliado();
    //========================================================================

    //========================================================================
    //STATS
    public float vida = 100f;
    public float velocidad = 10f;
    public float vidaMaxima;
    public float dano;
    //========================================================================

    void Start()
    {
        /*
        //ASIGNACIONES ESTADO COMBATE
        estadoCombate.vida = vidaMaxima;
        estadoCombate.vidaMaxima = vidaMaxima;

        //Inicialiamos el primer estado(en cual empieza)
        estadoActual = estadoMovimiento;
        */

        //"this" es una referencia al contexto(this EXACT monobehavour script)
        estadoActual.EnterState(this);
    }

    void Update()
    {
        estadoActual.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        estadoActual.OnCollisionEnter(this, collision);
    }

    public void CambiarEstado(Estado_Base_ALIADO estado)
    {
        estadoActual = estado;
        estadoActual.EnterState(this);
    }

    public void destruir()
    {
        Destroy(gameObject);
    }
}
