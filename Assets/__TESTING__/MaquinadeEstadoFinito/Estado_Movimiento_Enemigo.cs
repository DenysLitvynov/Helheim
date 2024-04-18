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
    public bool esta_en_combate = false;
    private GameObject aliadoIdentificado;
    


    public override void EnterState(Controlador_de_Estados enemigo)//el start del estado
    {
        Debug.Log("EMPEZANDO MOVIMIENTO");

        int numeroAleatorio = UnityEngine.Random.Range(1, 9);
        GameObject objWaypoints = GameObject.Find("LINEA" + numeroAleatorio);
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
