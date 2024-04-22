using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movimiento_Aliodos : MonoBehaviour
{


    public float velocidad = 10f;
    private Transform target;
    private Waypoints caminos;
    private int waypointIndex = 0;
    public bool esta_en_combate = false;
    private GameObject aliadoIdentificado;
    public bool colocado = false; 

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!colocado){
        
        float xCoordinate = transform.position.x;
        float zCoordinate = transform.position.z;

        // Stampiamo le coordinate per verificarle
        if(zCoordinate==(-10.83056f)){

            Debug.Log("Linea 1");
            GameObject objWaypoints = GameObject.Find("LINEA" + 1);
            caminos = objWaypoints.GetComponent<Waypoints>();
            target = caminos.points[waypointIndex];
        }else if(zCoordinate==(-9.759438f)){
            Debug.Log("Linea 2");
            GameObject objWaypoints = GameObject.Find("LINEA" + 2);
            caminos = objWaypoints.GetComponent<Waypoints>();
            target = caminos.points[waypointIndex];
        }else if(zCoordinate==(-8.250564f)){
            Debug.Log("Linea 3");
            GameObject objWaypoints = GameObject.Find("LINEA" + 3);
            caminos = objWaypoints.GetComponent<Waypoints>();
            target = caminos.points[waypointIndex];
        }else if(zCoordinate==(-7.179438f)){
            Debug.Log("Linea 4");
            GameObject objWaypoints = GameObject.Find("LINEA" + 4);
            caminos = objWaypoints.GetComponent<Waypoints>();
            target = caminos.points[waypointIndex];
        }else if(zCoordinate==(-5.680563f)){
            Debug.Log("Linea 5");
            GameObject objWaypoints = GameObject.Find("LINEA" + 5);
            caminos = objWaypoints.GetComponent<Waypoints>();
            target = caminos.points[waypointIndex];
        }else if(zCoordinate==(-4.609437f)){
            Debug.Log("Linea 6");
            GameObject objWaypoints = GameObject.Find("LINEA" + 6);
            caminos = objWaypoints.GetComponent<Waypoints>();
            target = caminos.points[waypointIndex];
        }else if(zCoordinate==(-3.100563f)){
            Debug.Log("Linea 7");
            GameObject objWaypoints = GameObject.Find("LINEA" + 7);
            caminos = objWaypoints.GetComponent<Waypoints>();
            target = caminos.points[waypointIndex];
        }else if(zCoordinate==(-2.029437f)){
            Debug.Log("Linea 8");
            GameObject objWaypoints = GameObject.Find("LINEA" + 8);
            caminos = objWaypoints.GetComponent<Waypoints>();
            target = caminos.points[waypointIndex];
        }
        Debug.Log("Coordinate sull'asse delle x: " + xCoordinate);
        Debug.Log("Coordinate sull'asse delle z: " + zCoordinate);
        
        }
        if (!esta_en_combate && colocado)
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

         //19.53277

        
    }


    void GetNextWaypoint()
    {
        waypointIndex--;
        if (waypointIndex < 0)
        {
            StopMovement();
            return;

        }
        target = caminos.points[waypointIndex];
    }

    void StopMovement()
{
    // Interrompi il movimento impostando la velocità a zero
    velocidad = 0f;
}

void move()
{
    // Interrompi il movimento impostando la velocità a zero
    velocidad = 3f;
}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigos")//Habra que hacer alguna funcion que al chocar devuelva el tag del objeto 
            //Asi establecer que da�o recibe el jefe.
        {
            esta_en_combate = true;
            aliadoIdentificado = collision.gameObject;
            StopMovement();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigos")
        {
            move();
            aliadoIdentificado = null;//Si el objeto con el que se paro de colosionar es Aliado. Es null, lo cual significa que
            // Esto indica que este objeto ya no est� en contacto con el objeto "Aliado".
            esta_en_combate = false;
        }
    }
}

