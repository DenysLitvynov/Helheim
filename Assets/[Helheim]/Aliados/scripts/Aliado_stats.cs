using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliado_stats : MonoBehaviour
{
    public bool combate_enemigo = false;
    public float vida_Maxima = 50f;//La vida maxima del aliado, solo para comparar y saber si se muere de una vez
    public float vida = 50f; // La vida del aliado
    public float dps = 5f;//da�o que causa el enemigo(el aliado tomara esto como parametro en recibirDa�o())
    //private Controlador_de_Estados enemigoControler;
    private Enemigo_stats enemigo;
    private Espectro_Stats espectro;

    private void Start()
    {
        vida = vida_Maxima;
    }

    private void Update()
    {
        if (combate_enemigo == true)
        {
            // Accede a la variable da�o_boss3 del enemigo
            if(enemigo!=null){
                recibirDano(enemigo.dano_enemigo);
            }else if(espectro!=null){
                recibirDano(espectro.daсo_espectro);

            }
            
        }
    }

    

    private void recibirDano(float dano)
    {
        if (combate_enemigo == true)
        {
            vida -= dano * Time.deltaTime;
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
            combate_enemigo = true;
            // Obtiene una referencia al objeto del aliado
            //enemigo = collision.gameObject.GetComponent<Enemigo_stats>();
            enemigo = collision.gameObject.GetComponent<Enemigo_stats>();
            espectro = collision.gameObject.GetComponent<Espectro_Stats>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            combate_enemigo = false;
        }
    }
}