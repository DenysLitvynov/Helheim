using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliado : MonoBehaviour
{
    //===========================================================================================
    [Header("------------MOVIMIENTO--------------")]
    public float velocidad = 5f;
    public bool esta_en_combate = false;
    public bool colocado = false;
    private GameObject enemigoIdentificado;
    public ParticleSystem spawn;

    // Offset fijo para la posición Y
    private float fixedYOffset = 0.15f; // Ajusta este valor según sea necesario
    [SerializeField] Animator animator;  // Referencia al Animator
    //============================================================================================

    //==========================================================================================================
    [Header("----------------COMBATE--------------")]
    public float vida_Maxima = 50f;//La vida maxima del aliado, solo para comparar y saber si se muere de una vez
    private float vida; // La vida del aliado
    public float dps = 5f;//da�o que causa el enemigo(el aliado tomara esto como parametro en recibirDa�o())
    //private Controlador_de_Estados enemigoControler;
    private Enemigo_stats enemigo;
    private Espectro_Stats espectro;
    public ParticleSystem particulasMuerte;
    //==========================================================================================================

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!esta_en_combate && colocado)
        {
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

        }
    }

    //===============================================================================================================
    private void Colocar()
    {
        colocado = true;
        // Usa la posición del transform y ajusta solo el eje Y
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + fixedYOffset, transform.position.z);

        // Ajuste de rotación para que el sistema de partículas mire hacia arriba
        Quaternion rotation = Quaternion.Euler(-90, 0, 0);
        ParticleSystem effectInstance = Instantiate(spawn, spawnPosition, rotation);
        animator.SetBool("Colocado", colocado);
    }

    private void Mover()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        float xCoordinate = transform.position.x;
    }

    private void recibirDano(float dano)
    {
        if (esta_en_combate == true)
        {
            vida -= dano * Time.deltaTime;
            // Establecer el booleano en el Animator
               animator.SetBool("EstaEnCombate", esta_en_combate);

        }
        // Comprueba si la vida del aliado ha llegado a 0
        if (vida <= 0)
        {
            Morir();// Destruye el aliado
        }
    }

    public void Morir()
    {
        Destroy(gameObject); // Destruye el enemigo
        Instantiate(particulasMuerte, transform.position, Quaternion.identity);
    }
    //===============================================================================================================

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")//Habra que hacer alguna funcion que al chocar devuelva el tag del objeto 
                                                  //Asi establecer que da�o recibe el jefe.
        {
            esta_en_combate = true;
            enemigoIdentificado = collision.gameObject;
            velocidad = 0;
            enemigo = collision.gameObject.GetComponent<Enemigo_stats>();
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

            enemigoIdentificado = null;//Si el objeto con el que se paro de colosionar es Enemigo. Es null, lo cual significa que
            // Esto indica que este objeto ya no est� en contacto con el objeto "Enemigo".
            esta_en_combate = false;
        }
    }


}
