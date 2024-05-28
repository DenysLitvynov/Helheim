using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MjolnirController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] Truenos;
    [SerializeField] BoxCollider[] colliders; // Asegúrate de asignar tus colliders aquí en el Inspector
    public float delay = 5f;
    public Animator animator; // El Animator del objeto
    Movimiento_Aliodos colocadoCarta;
  

    void Start()
    {
        // Desactiva todos los sistemas de partículas al inicio
        foreach (ParticleSystem trueno in Truenos)
        {
            trueno.Stop();
        }
        colocadoCarta = GetComponent<Movimiento_Aliodos>();

    }

    void Update()
    {
        if (colocadoCarta.colocado)
        {
            // Si el objeto está colocado, reproduce la animación
            animator.SetBool("Colocado", true);
        }
        else
        {
            // Si el objeto no está colocado, detiene la animación
            animator.SetBool("Colocado", false);
        }
    }

    // Esta función se llamará al final de la animación
    public void ActivarTruenos()
    {
        foreach (ParticleSystem trueno in Truenos)
        {
            trueno.Play();
        }

        foreach (BoxCollider collider in colliders)
        {
            collider.enabled = true;
        }
        Destroy(gameObject, delay);
    }
}
