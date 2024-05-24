using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeCasa : MonoBehaviour
{
    public GameObject Casa;
    public GameObject CasaEstado2;
    public GameObject CasaEstado3;

    public ComportamientoBarra vida;

    private void Update()
    {
        float saludActual = vida.vidaActual;

        if (saludActual <= 25)
        {
            Casa.SetActive(false);
            CasaEstado2.SetActive(false);
            CasaEstado3.SetActive(true);
        }
        else if (saludActual <= 50)
        {
            Casa.SetActive(false);
            CasaEstado2.SetActive(true);
            CasaEstado3.SetActive(false);
        }
        else
        {
            Casa.SetActive(true);
            CasaEstado2.SetActive(false);
            CasaEstado3.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemigo" || other.gameObject.tag == "Enemy")
        {
            Enemigo_stats enemigo = other.gameObject.GetComponent<Enemigo_stats>();
            Espectro_Stats espectro = other.gameObject.GetComponent<Espectro_Stats>();

            if (enemigo != null)
            {
                float dano = enemigo.dano_enemigo; // Obtener el daño del enemigo
                vida.restarVida(dano);
            }
            else if (espectro != null)
            {
                float dano = espectro.daсo_espectro; // Obtener el daño del espectro
                vida.restarVida(dano);
            }
        }
    }
}
