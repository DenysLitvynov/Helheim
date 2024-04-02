using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_aliado_dummy : MonoBehaviour
{
    private bool combate_aliado = false;
    public float vida = 50f; // La vida del enemigo
    public float dps = 5f;

    private void Update()
    {
        recibirDaño();
    }

    private void recibirDaño()
    {
        if (combate_aliado == true)
        {
            vida -= dps * Time.deltaTime;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye el enemigo
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            combate_aliado = true;
        }
    }
}