using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Estado_Movimiento_Enemigo : Estado_Base_Enemigo
{

    public float velocidad = 10f;
    private Transform target;
    private Waypoints caminos;
    private int waypointIndex = 0;
    public int filaSelecionada;
    private Movimento_Frecha frecha;
    
    public override void EnterState(Controlador_de_Estados enemigo)//el start del estado
    {
        Debug.Log("EMPEZANDO MOVIMIENTO");
        GameObject objWaypoints = GameObject.Find("LINEA" +3);//fila selecionada
        caminos = objWaypoints.GetComponent<Waypoints>();
        target = caminos.points[waypointIndex];
    }

    public override void UpdateState(Controlador_de_Estados enemigo)//el update del estado
    {
        Vector3 dir = target.position - enemigo.transform.position;
        enemigo.transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        if (Vector3.Distance(enemigo.transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint(enemigo.gameObject);
        }

    }

    public override void OnCollisionEnter(Controlador_de_Estados enemigo, Collision collision)
    {
        if (collision.gameObject.CompareTag("Aliado"))
        {
            enemigo.CambiarEstado(enemigo.estadoCombate);
        }
        else if (collision.gameObject.CompareTag("Flecha"))
        {
            frecha = collision.gameObject.GetComponent<Movimento_Frecha>();
            enemigo.estadoCombate.recibirDano(enemigo,frecha.dps);
            Debug.Log("VIDA PERDIDA EN MOVIMIENTO:"+enemigo.estadoCombate.vida);
        }
        /*
           if (collision.gameObject.layer == LayerMask.NameToLayer("Flecha"))
           {
               frecha = collision.gameObject.GetComponent<Movimento_Frecha>();
               // Obtiene una referencia al componente Estado_combate_enemigo
               enemigo.estadoCombate.recibirDano(frecha.dps, enemigo);
               /*
               Debug.Log("DAÑO DE LA FLECHA:" +enemigo.estadoCombate.dano_recibido);
               Debug.Log("VIDA ACTUAL:" + enemigo.estadoCombate.vida);

           }
           else
           {
               enemigo.CambiarEstado(enemigo.estadoCombate);
           }
           */
    }

    void GetNextWaypoint(GameObject gameObject)
    {

        waypointIndex++;
        if (waypointIndex >= caminos.points.Length - 1)
        {
            Controlador_de_Estados.Destroy(gameObject);
            return;
        }

        target = caminos.points[waypointIndex];
    }

}
