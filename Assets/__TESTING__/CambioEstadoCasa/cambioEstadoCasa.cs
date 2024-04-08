using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeCasa : MonoBehaviour
{

    public GameObject Casa;

    public GameObject CasaEstado2;

    public GameObject CasaEstado3;

    public ComportamientoBarra vida;

    public float dano = 25f;
    private void Update()
    {



        float saludActual = vida.vidaActual;



        if (saludActual <= 25){

            Casa.SetActive(false);

            CasaEstado2.SetActive(false);

            CasaEstado3.SetActive(true);
            
        }

        else if (saludActual <= 50){

            Casa.SetActive(false);

            CasaEstado2.SetActive(true);

            CasaEstado3.SetActive(false);
            
        }

        else{

            Casa.SetActive(true);

            CasaEstado2.SetActive(false);

            CasaEstado3.SetActive(false);
            
        }

    }

    private void OnCollisionEnter(Collision other){

        if (other.gameObject.tag == "Enemigo" || other.gameObject.tag == "Enemy"){
            
            // No destruimos para no ocasionar errores al borrarse por el Spawner

            //Destroy(other.gameObject);

            vida.restarVida(dano);

        }

    }
}