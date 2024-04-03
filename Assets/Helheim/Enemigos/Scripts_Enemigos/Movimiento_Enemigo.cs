using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movimiento_Enemigo : MonoBehaviour
{


    public float velocidad = 10f;
    private Transform target;
    private Waypoints caminos;
    private int waypointIndex = 0;
    public bool esta_en_combate = false;
    private GameObject aliadoIdentificado;

    private void Start()
    {
        int numeroAleatorio = UnityEngine.Random.Range(1, 9);
        GameObject objWaypoints = GameObject.Find("LINEA" + numeroAleatorio);
        caminos = objWaypoints.GetComponent<Waypoints>();
        target = caminos.points[waypointIndex];
    }

    private void Update()
    {
        if (!esta_en_combate)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }
        }
        //Si el jefe est� en combate pero el
        //objeto "Aliado" con el que estaba en combate ha sido destruido (es decir, aliadoIdentificado es null)...
        else if (aliadoIdentificado == null)
        {
            // Establece que el jefe ya no est� en combate.
            esta_en_combate = false;
        }
    }

    void GetNextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex >= caminos.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        target = caminos.points[waypointIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")//Habra que hacer alguna funcion que al chocar devuelva el tag del objeto 
            //Asi establecer que da�o recibe el jefe.
        {
            esta_en_combate = true;
            aliadoIdentificado = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            aliadoIdentificado = null;//Si el objeto con el que se paro de colosionar es Aliado. Es null, lo cual significa que
            // Esto indica que este objeto ya no est� en contacto con el objeto "Aliado".
            esta_en_combate = false;
        }
    }
}

