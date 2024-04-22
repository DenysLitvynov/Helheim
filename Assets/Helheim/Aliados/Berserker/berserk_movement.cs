using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Berserk : MonoBehaviour
{
    public float velocidad = 5f;
    public bool esta_en_combate = false;
    public bool colocado = false;

    private GameObject aliadoIdentificado;

    private void Update()
    {
        if (!esta_en_combate && colocado)
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
        /*
        IF esta en combate y el objeto "Aliado" combatiente ha sido destruido 
        */
        else if (aliadoIdentificado == null)
        {
            // Establece que el jefe ya no est� en combate.
            esta_en_combate = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")//Habra que hacer alguna funcion que al chocar devuelva el tag del objeto 
                                                   //Asi establecer que da�o recibe el jefe.
        {
            esta_en_combate = true;
            aliadoIdentificado = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            aliadoIdentificado = null;//Si el objeto con el que se paro de colosionar es Aliado. Es null, lo cual significa que
            // Esto indica que este objeto ya no est� en contacto con el objeto "Aliado".
            esta_en_combate = false;
        }
    }
}
