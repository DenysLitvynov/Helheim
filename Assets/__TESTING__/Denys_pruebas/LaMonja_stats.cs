using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaMonja_Stats : MonoBehaviour
{
    public float vida_maxima = 100f; // La vida maxima de la monja
    public float vida = 100f; // La vida de la monja
    public GameObject espectroPrefab; // El prefab del espectro que la monja va a invocar
    public float tiempoEntreInvocaciones = 5f; // El tiempo entre cada invocación
    public float distanciaDeInvocacion = 2f; // La distancia a la que se invocarán los espectros

    private void Start()
    {
        // Comienza a invocar espectros
        StartCoroutine(InvocarEspectros());
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
}
