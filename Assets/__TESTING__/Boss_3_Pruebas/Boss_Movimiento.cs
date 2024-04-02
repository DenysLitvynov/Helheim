using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss_Movimiento : MonoBehaviour
{
   

    public float velocidad = 10f;
    private Transform target;
    private Waypoints caminos;
    private int waypointIndex = 0;

    private void Start()
    {
        int numeroAleatorio = UnityEngine.Random.Range(1, 9);
        GameObject objWaypoints = GameObject.Find("LINEA"+numeroAleatorio);
        caminos = objWaypoints.GetComponent<Waypoints>();
        target = caminos.points[waypointIndex];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex>=caminos.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        target = caminos.points[waypointIndex];
    }
}

