using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MjolnirController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] Truenos;
    [SerializeField] BoxCollider[] colliders; // Aseg�rate de asignar tus colliders aqu� en el Inspector
    public float delay = 5f;
    public Animator animator; // El Animator del objeto
    Movimiento_Aliodos colocadoCarta;
  

    void Start()
    {
        // Desactiva todos los sistemas de part�culas al inicio
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
            // Si el objeto est� colocado, reproduce la animaci�n
            animator.SetBool("Colocado", true);
        }
        else
        {
            // Si el objeto no est� colocado, detiene la animaci�n
            animator.SetBool("Colocado", false);
        }
    }

    // Esta funci�n se llamar� al final de la animaci�n
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
