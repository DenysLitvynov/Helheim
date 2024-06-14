using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MjolnirController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] Truenos;
    [SerializeField] BoxCollider[] colliders; // Asegúrate de asignar tus colliders aquí en el Inspector
    public float delay = 3f;
    public Animator animator; // El Animator del objeto
    [SerializeField] Movimiento_Aliodos colocadoCarta;
    public int danomartillo = 200;
    private AudioSource audioSource;
    private AudioClip truenos;

    private Espectro_Stats espectro;

    void Start()
    {
        // Desactiva todos los sistemas de partículas al inicio
        foreach (ParticleSystem trueno in Truenos)
        {
            trueno.Stop();
        }
        audioSource = GetComponent<AudioSource>();
        

    }

    void Update()
    {
        if(colocadoCarta != null){

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
       

        if(colocadoCarta == true)
        {
            Destroy(this.gameObject, delay);
        }
    }

    private void playSonidoTruenos()
    {
        audioSource.PlayOneShot(truenos);
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo"&&collision.gameObject!=null)
        {
            collision.gameObject.GetComponent<Enemigo>().recibirDano(danomartillo);

            Debug.Log("MARTILLO ESTA HACIENDO DAÑO EN AMBOS EJES"+danomartillo);
        }
        
    }
    */

}


