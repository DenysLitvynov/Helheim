using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_2 : MonoBehaviour
{
    private Transform target;
    private Waypoints caminos;
    private int waypointIndex = 0;
    private GameObject aliadoIdentificado;

    public float velocidad = 6f;
    public float vida = 200f;
    public bool esta_en_combate = false;


    // Start is called before the first frame update
    void Start()
    {
        lineaAleatoria();
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 100f) // Verificar si la vida está por debajo del 50%
        {
            lineaAleatoria();
        }
        if (vida <= 50f) // Verificar si la vida está por debajo del 25%
        {
            lineaAleatoria();
        }
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
    void lineaAleatoria(){
        int numeroAleatorio = UnityEngine.Random.Range(1, 9);
        GameObject objWaypoints = GameObject.Find("LINEA" + numeroAleatorio);
        caminos = objWaypoints.GetComponent<Waypoints>();
        target = caminos.points[waypointIndex];
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
