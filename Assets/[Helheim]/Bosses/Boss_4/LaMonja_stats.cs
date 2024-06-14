using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaMonja_Stats : MonoBehaviour
{
    private Movimiento_Enemigo combate;

    // private bool combate_monja = false;
    public float vida_maxima = 100f; // La vida maxima de la monja
    public float vida = 100f; // La vida de la monja
    public GameObject espectroPrefab; // El prefab del espectro que la monja va a invocar
    public float tiempoEntreInvocaciones = 5f; // El tiempo entre cada invocación
    public float distanciaDeInvocacion = 2f; // La distancia a la que se invocarán los espectros
    private Aliado aliado; // Referencia al aliado

    public int maxEspectros = 5; // El número máximo de espectros que la monja puede invocar
    private int espectrosActuales = 0; // El número actual de espectros invocados

    private WaveSpawner waveSpawner; // Referencia al WaveSpawner


    private void Start()
    {
        // Obtiene la referencia al WaveSpawner
        waveSpawner = FindObjectOfType<WaveSpawner>();

        combate = GetComponent<Movimiento_Enemigo>();

        // Comienza a invocar espectros
        StartCoroutine(InvocarEspectros());
    }

    private void Update()
    {
        if (combate.esta_en_combate == true)
        {
            // Comprueba si aliado no es null antes de acceder a aliado.dps
            if (aliado != null)
            {
                recibirDano(aliado.dps);
            }
            else
            {
                Debug.Log("Aliado es null");
            }
        }
    }

    private void recibirDano(float dano)
    {
        if (combate.esta_en_combate == true)
        {
            vida -= dano * Time.deltaTime;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (vida <= 0 || dano > vida_maxima)
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
            aliado = collision.gameObject.GetComponent<Aliado>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            combate.esta_en_combate = false;
        }
    }

    private IEnumerator InvocarEspectros()
    {
        while (espectrosActuales < maxEspectros)
        {
            Vector3 posicionDeInvocacion = transform.position + transform.right * distanciaDeInvocacion;
            GameObject espectro = Instantiate(espectroPrefab, posicionDeInvocacion, Quaternion.identity);
            espectrosActuales++; // Incrementa el contador de espectros invocados

            // Incrementa el contador de enemigos activos en WaveSpawner
            waveSpawner.IncrementActiveEnemies();

            yield return new WaitForSeconds(tiempoEntreInvocaciones);
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            combate_monja = true;
            // Obtiene una referencia al objeto del aliado
            aliado = collision.gameObject.GetComponent<Aliado_stats>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            combate_monja = false;
        }
    }
    */
    
}