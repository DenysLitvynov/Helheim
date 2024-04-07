using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaMonja_Stats : MonoBehaviour
{
    private bool combate_monja = false;
    public float vida_maxima = 100f; // La vida maxima de la monja
    public float vida = 100f; // La vida de la monja
    public GameObject espectroPrefab; // El prefab del espectro que la monja va a invocar
    public float tiempoEntreInvocaciones = 5f; // El tiempo entre cada invocación
    public float distanciaDeInvocacion = 2f; // La distancia a la que se invocarán los espectros
    private Aliado_stats aliado; // Referencia al aliado

    public int maxEspectros = 5; // El número máximo de espectros que la monja puede invocar
    private int espectrosActuales = 0; // El número actual de espectros invocados

    private WaveSpawner waveSpawner; // Referencia al WaveSpawner


    private void Start()
    {
        // Obtiene la referencia al WaveSpawner
        waveSpawner = FindObjectOfType<WaveSpawner>();

        // Comienza a invocar espectros
        StartCoroutine(InvocarEspectros());
    }

    private void Update()
    {
        if (combate_monja == true)
        {
            // Accede a la variable de daño del aliado
            recibirDano(aliado.dps);
        }

        // Comprueba si la vida de la monja ha llegado a 0
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye la monja
        }
    }

    private void recibirDano(float dano)
    {
        if (combate_monja == true)
        {
            vida -= dano * Time.deltaTime;
        }
        // Comprueba si la vida de la monja ha llegado a 0
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye la monja
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
}