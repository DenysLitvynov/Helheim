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
        if (combate_aliado == true)
        {
            // Obtiene una referencia al objeto del enemigo
            Boss3_vida enemigo = GameObject.FindObjectOfType<Boss3_vida>();

            // Accede a la variable da�o_boss3 del enemigo
            recibirDa�o(enemigo.da�o_boss);
        }
    }

    private void recibirDa�o(float da�o)
    {
        if (combate_aliado == true)
        {
            vida -= da�o * Time.deltaTime;
        }
        // Comprueba si la vida del aliado ha llegado a 0
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye el aliado
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