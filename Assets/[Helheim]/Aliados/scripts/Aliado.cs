using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliado : MonoBehaviour
{

    [SerializeField] Animator animator;  // Referencia al Animator

    //===========================================================================================
    [Header("-----------------Movimiento-----------------")]
    public float velocidad = 5f;
   
    public bool colocado = false;
    [SerializeField] bool SePuedeMover;

    //============================================================================================

    //==========================================================================================================
    [Header("-----------------Combate-----------------")]
    public bool esta_en_combate = false;
    public float vida_Maxima = 50f;//La vida maxima del aliado, solo para comparar y saber si se muere de una vez
    public float vida = 50f; // La vida del aliado
    public float dps = 5f;//da�o que causa el enemigo(el aliado tomara esto como parametro en recibirDa�o())
    //private Controlador_de_Estados enemigoControler;
    private Enemigo enemigo;
    private Espectro_Stats espectro;
    //==========================================================================================================
    [Header("-----------------FX Y SFX-----------------")]
    public ParticleSystem spawn;
    private float fixedYOffset = 0.15f; // Ajusta este valor según sea necesario
    private bool spawnEffectInstanciado = false;
    public ParticleSystem particulasMuerte;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] EfectosDesonido;


    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++_____FUNCIONES DE UNITY_______++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        vida = vida_Maxima;
    }

    // Update is called once per frame
    void Update()
    {
        if (!esta_en_combate) { 
         Mover();
        }


        if (esta_en_combate == true)
        {
            // Accede a la variable da�o_boss3 del enemigo
            if (enemigo != null)
            {
                recibirDano(enemigo.dano_enemigo);
            }
            else if (espectro != null)
            {
                recibirDano(espectro.daсo_espectro);

            }
            if(enemigo==null )
            {
                esta_en_combate=false;
            }

        }

        if (colocado && !spawnEffectInstanciado)
        {
            // Usa la posición del transform y ajusta solo el eje Y
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + fixedYOffset, transform.position.z);
            // Ajuste de rotación para que el sistema de partículas mire hacia arriba
            Quaternion rotation = Quaternion.Euler(-90, 0, 0);
            ParticleSystem effectInstance = Instantiate(spawn, spawnPosition, rotation);
            spawnEffectInstanciado = true;
            audioSource.PlayOneShot(EfectosDesonido[0]);//EFECTO DE SONIDO AL CAMINAR
        }

        if(animator!=null)
        {
            // Establecer el booleano en el Animator
            animator.SetBool("EstaEnCombate", esta_en_combate);
            animator.SetBool("Colocado", colocado);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")//Habra que hacer alguna funcion que al chocar devuelva el tag del objeto 
                                                  //Asi establecer que da�o recibe el jefe.
        {
            esta_en_combate = true;
            enemigo = collision.gameObject.GetComponent<Enemigo>();
            espectro = collision.gameObject.GetComponent<Espectro_Stats>();

        }
        else if (collision.gameObject.tag == "Entorno")
        {

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {

            enemigo = null;//Si el objeto con el que se paro de colosionar es Enemigo. Es null, lo cual significa que
            // Esto indica que este objeto ya no est� en contacto con el objeto "Enemigo".
            esta_en_combate = false;
        }
    }


    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++_______FUNCIONES DE UNITY_______++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++_____FUNCIONES DE MOVIMIENTO_______++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
   

    private void Mover()
    {
        if (!esta_en_combate && colocado && SePuedeMover)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            

        }
    }

    void empezarMovimiento()
    {
        SePuedeMover = true;
        audioSource.PlayOneShot(EfectosDesonido[1]);//EFECTO DE SONIDO AL CAMINAR
    }
    void PararMovimiento()
    {
        SePuedeMover = false;
        audioSource.PlayOneShot(EfectosDesonido[1]);//EFECTO DE SONIDO AL CAMINAR
    }
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++_____FUNCIONES DE MOVIMIENTO_______++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++_____FUNCIONES DE COMBATE_______++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void recibirDano(float dano)
    {
        if (esta_en_combate == true)
        {
            vida -= dano * Time.deltaTime;
            // Establecer el booleano en el Animator

        }
        // Comprueba si la vida del aliado ha llegado a 0
        if (vida <= 0||dano>=vida_Maxima)
        {
            Morir();// Destruye el aliado
        }
    }

    void playSonidoAtaque()
    {
        audioSource.PlayOneShot(EfectosDesonido[2]);//EFECTO DE SONIDO AL CAMINAR
    }

    public void Morir()
    {
        Destroy(gameObject); // Destruye el enemigo
        Instantiate(particulasMuerte, transform.position, Quaternion.identity);
    }
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++_____FUNCIONES DE COMBATE_______++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


}
