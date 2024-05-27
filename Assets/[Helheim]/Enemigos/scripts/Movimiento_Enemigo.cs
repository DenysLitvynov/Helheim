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
    [SerializeField] Animator animator;  // Referencia al Animator

    private void Start()
    {
        int numeroAleatorio = UnityEngine.Random.Range(1, 9);
        GameObject objWaypoints = GameObject.Find("LINEA" + numeroAleatorio);
        caminos = objWaypoints.GetComponent<Waypoints>();

        // Establece el waypoint inicial en la posición actual del enemigo
        waypointIndex = ClosestWaypoint();

        target = caminos.points[waypointIndex];

        // Obtener el Animator adjunto al GameObject
        animator = GetComponent<Animator>();
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
        // Si el jefe está en combate pero el objeto "Aliado" con el que estaba en combate ha sido destruido (es decir, aliadoIdentificado es null)...
        else if (aliadoIdentificado == null)
        {
            // Establece que el jefe ya no está en combate.
            esta_en_combate = false;
        }

        // Establecer el booleano en el Animator
        animator.SetBool("EstaEnCombate", esta_en_combate);
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
        if (collision.gameObject.tag == "Aliado") // Habrá que hacer alguna función que al chocar devuelva el tag del objeto 
        {
            esta_en_combate = true;
            aliadoIdentificado = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            aliadoIdentificado = null; // Si el objeto con el que se paró de colisionar es Aliado, es null, lo cual significa que
            // esto indica que este objeto ya no está en contacto con el objeto "Aliado".
            esta_en_combate = false;
        }
    }

    // Método necesario para el correcto espawneo de los enemigos
    private int ClosestWaypoint()
    {
        int closestIndex = 0;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < caminos.points.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, caminos.points[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}
