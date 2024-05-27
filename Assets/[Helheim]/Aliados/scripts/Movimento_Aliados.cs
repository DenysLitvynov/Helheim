using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movimiento_Aliodos : MonoBehaviour
{

    public float velocidad = 5f;
    public bool esta_en_combate = false;
    private float velocidad2;
    public bool colocado = false;

    private GameObject aliadoIdentificado;

    private void Start()
    {
        velocidad2 = velocidad;
    }

    private void Update()
    {
        if (!esta_en_combate && colocado)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            float xCoordinate = transform.position.x;
            if(xCoordinate>18.53277f){
                StopMovement();
            }else{
                velocidad = velocidad2;
            }
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
         //

        

    void StopMovement()
{
    // Interrompi il movimento impostando la velocità a zero
    velocidad = 0f;
}

    void move()
    {
        // Interrompi il movimento impostando la velocità a zero
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")//Habra que hacer alguna funcion que al chocar devuelva el tag del objeto 
            //Asi establecer que da�o recibe el jefe.
        {
            esta_en_combate = true;
            aliadoIdentificado = collision.gameObject;
            StopMovement();
        }
        else if (collision.gameObject.tag == "Entorno")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            
            aliadoIdentificado = null;//Si el objeto con el que se paro de colosionar es Enemigo. Es null, lo cual significa que
            // Esto indica que este objeto ya no est� en contacto con el objeto "Enemigo".
            esta_en_combate = false;
        }
    }
}

