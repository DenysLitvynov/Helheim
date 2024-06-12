using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Animator animator;  // Referencia al Animator

    [Header("-----------------Movimiento-----------------")]
    [SerializeField] float velocidad = 1f;
    private Transform target;
    private Waypoints caminos;
    private int waypointIndex = 0;
    private GameObject aliadoIdentificado;
    private bool SepuedeMover=true;

    [Header("-----------------Combate-----------------")]
    public bool esta_en_combate = false;
    public float vida_maxima = 100f;//La vida maxima del enemigo, solo para comparar y saber si se muere de una vez
    public float vida = 100f; // La vida del enemigo
    public float dano_enemigo = 15f;//da�o que causa el enemigo(el aliado tomara esto como parametro en recibirDa�o())
    private Aliado aliado;
    private Movimento_Frecha frecha;
    public CharacterCardManager cartas;
    public CharacterCardScriptableObject martillo;
    public CharacterCardScriptableObject berserk;

    [Header("-----------------FX Y SFX-----------------")]
    public ParticleSystem particulasMuerte;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] EfectosDesonido;


    //======================================_________FUNCIONCES UNITY_________===========================================================
    private void Start()
    {
        int numeroAleatorio = UnityEngine.Random.Range(1, 9);
        GameObject objWaypoints = GameObject.Find("LINEA" + numeroAleatorio);
        caminos = objWaypoints.GetComponent<Waypoints>();

        // Establece el waypoint inicial en la posición actual del enemigo
        waypointIndex = ClosestWaypoint();

        target = caminos.points[waypointIndex];

        // Obtener el Animator adjunto al GameObject
        animator = GetComponent<Animator>();

        vida = vida_maxima;
        GameObject characterManagerObject = GameObject.Find("Game Manager");
        cartas = characterManagerObject.GetComponent<CharacterCardManager>();
      
    }

    private void Update()
    {
          // Si el jefe está en combate pero el objeto "Aliado" con el que estaba en combate ha sido destruido (es decir, aliadoIdentificado es null)...
         if (aliadoIdentificado == null)
        {
            // Establece que el jefe ya no está en combate.
            esta_en_combate = false;
        }

        if (esta_en_combate && aliado != null)
        {
            // Accede a la variable dps del aliado
            recibirDano(aliado.dps);
        }

        // Establecer el booleano en el Animator
        animator.SetBool("EstaEnCombate", esta_en_combate);

        Mover();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado") // Habrá que hacer alguna función que al chocar devuelva el tag del objeto 
        {
            esta_en_combate = true;
            aliadoIdentificado = collision.gameObject;
         
                // Obtiene una referencia al objeto del aliado
                aliado = collision.gameObject.GetComponent<Aliado>();

        }
        else if (collision.gameObject.CompareTag("Flecha"))
        {
            frecha = collision.gameObject.GetComponent<Movimento_Frecha>();
            recibirDano(frecha.dps);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            aliadoIdentificado = null; // Si el objeto con el que se paró de colisionar es Aliado, es null, lo cual significa que
            // esto indica que este objeto ya no está en contacto con el objeto "Aliado".
            esta_en_combate = false;
        }
    }


    //======================================_________FUNCIONCES UNITY_________===========================================================

    //======================================_________FUNCIONCES MOVIMIENTO_________===========================================================

    void Mover()
    {
        if (!esta_en_combate &&SepuedeMover) { 
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);
            audioSource.PlayOneShot(EfectosDesonido[0]);//EFECTO DE SONIDO AL CAMINAR

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
                
            }
            return;
        }
    }
    
    void empezarMovimiento()
    {
        SepuedeMover = true;
    }
    void detenerMovimient() 
    {
        SepuedeMover = false;
    }

    void GetNextWaypoint()
    {
        waypointIndex++;
        if (waypointIndex >= caminos.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        target = caminos.points[waypointIndex];
    }

    // Método necesario para el correcto espawneo de los enemigos
    private int ClosestWaypoint()
    {
        int closestIndex = 0;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < caminos.points.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, caminos.points[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
    //=======================================================================______FUNCIONCES MOVIMIENTO______==============================================================

    //======================================================================_________FUNCIONCES COMBATE_________===========================================================
    private void recibirDano(float dano)
    {
        if (esta_en_combate == true)
        {
            vida -= dano * Time.deltaTime;
            // Establecer el booleano en el Animator
            audioSource.PlayOneShot(EfectosDesonido[1]);//EFECTO DE SONIDO AL CAMINAR

            if (vida <= 0 || dano >= vida_maxima)
            {
                Morir();// Destruye el aliado
            }
        }
        // Comprueba si la vida del aliado ha llegado a 0
      
    }

    public void Morir()
    {
        Destroy(gameObject); // Destruye el enemigo
        // Define un desplazamiento en el eje Y
        Vector3 posicion = transform.position + new Vector3(0, 1.0f, 0); // Ajusta el valor 1.0f según sea necesario
        Instantiate(particulasMuerte, posicion, Quaternion.identity);
        
        if (DropCarta())
        {
            cartaAleatoria();
        }
        audioSource.PlayOneShot(EfectosDesonido[2]);//EFECTO DE SONIDO AL CAMINAR
    }

    public void cartaAleatoria()
    {
        if (cartas.amtOfCards < 10)
        {
            cartas.amtOfCards++;

            if (GenerateRandomNumber() == 1)
            {
                cartas.characterCardSO[cartas.amtOfCards - 1] = martillo;
            }
            else
            {
                cartas.characterCardSO[cartas.amtOfCards - 1] = berserk;
            }

            cartas.characterCards = new GameObject[cartas.amtOfCards];
            cartas.AddCharacterCard(cartas.amtOfCards - 1);
        }


    }

    int GenerateRandomNumber()
    {
        // Genera un número aleatorio entre 0 (inclusive) y 1 (exclusivo)
        float randomNumber = UnityEngine.Random.value;

        // Si el número generado es menor o igual a 0.5, devuelve 1; de lo contrario, devuelve 2
        if (randomNumber <= 0.5f)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    bool DropCarta()
    {
        // Genera un número aleatorio entre 0 (inclusive) y 1 (exclusivo)
        float randomNumber = UnityEngine.Random.value;

        // Si el número generado es menor o igual a 0.2, devuelve verdadero; de lo contrario, devuelve falso
        return randomNumber <= 0.2f;
    }
    //======================================_________FUNCIONCES COMBATE_________===========================================================
}
