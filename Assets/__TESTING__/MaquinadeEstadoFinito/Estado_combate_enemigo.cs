using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado_combate_enemigo : Estado_Base_Enemigo
{
    public override  void EnterState(Controlador_de_Estados enemigo)
    {
        Debug.Log("HOLA DESDE EL ESTADO COMBATE");
    }

    public  override void UpdateState(Controlador_de_Estados enemigo)
    {

    }

    public override  void OnCollisionEnter(Controlador_de_Estados enemigo, Collision collision)
    {

    }
}
