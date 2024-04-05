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

    private void Start()
    {
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
        while (true)
        {
            // Calcula la posición de invocación a la izquierda o a la derecha de la monja
            Vector3 posicionDeInvocacion = transform.position + transform.right * distanciaDeInvocacion;

            // Crea un nuevo espectro en la posición de invocación
            Instantiate(espectroPrefab, posicionDeInvocacion, Quaternion.identity);

            // Espera el tiempo especificado antes de la próxima invocación
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