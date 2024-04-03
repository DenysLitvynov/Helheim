using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_vida : MonoBehaviour
{
    private Boss_Movimiento combate;
    public float vida_maxima = 100f;
    public float vida = 100f; // La vida del enemigo
    public float da�o_boss = 40f;
    private Vida_aliado_dummy aliado;

    private void Start()
    {
        combate = GetComponent<Boss_Movimiento>();
    }

    private void Update()
    {
        if (combate.esta_en_combate == true)
        {
            // Accede a la variable dps del aliado
            recibirDa�o(aliado.dps);
        }
    }

    private void recibirDa�o(float da�o)
    {
        if (combate.esta_en_combate == true)
        {
            vida -= da�o * Time.deltaTime;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (vida <= 0 || da�o > vida_maxima) 
        {
            Destroy(gameObject); // Destruye el enemigo
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            combate.esta_en_combate = true;
            // Obtiene una referencia al objeto del aliado
            aliado = collision.gameObject.GetComponent<Vida_aliado_dummy>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            combate.esta_en_combate = false;
        }
    }
}
