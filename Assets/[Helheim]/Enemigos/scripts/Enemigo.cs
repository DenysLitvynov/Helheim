using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("------Movimiento------")]
    public float velocidad = 10f;
    private Transform target;
    private Waypoints caminos;
    private int waypointIndex = 0;
    public bool esta_en_combate = false;
    private GameObject aliadoIdentificado;
    [SerializeField] Animator animator;  // Referencia al Animator

    [Header("------Combate------")]
    public float vida_maxima = 100f;//La vida maxima del enemigo, solo para comparar y saber si se muere de una vez
    public float vida = 100f; // La vida del enemigo
    public float dano_enemigo = 15f;//da�o que causa el enemigo(el aliado tomara esto como parametro en recibirDa�o())
    private Aliado_stats aliado;
    private Movimento_Frecha frecha;

    public CharacterCardManager cartas;
    public ParticleSystem particulasMuerte;
    public CharacterCardScriptableObject martillo;
    public CharacterCardScriptableObject berserk;

    // Start is called before the first frame update
    void Start()
    {
        //COMBATE
        vida = vida_maxima;
        GameObject characterManagerObject = GameObject.Find("Game Manager");
        esta_en_combate = GetComponent<Movimiento_Enemigo>();
        cartas = characterManagerObject.GetComponent<CharacterCardManager>();

        //MOVIMIENTO
        int numeroAleatorio = Random.Range(1, 9);
        GameObject objWaypoints = GameObject.Find("LINEA" + numeroAleatorio);
        caminos = objWaypoints.GetComponent<Waypoints>();

        // Establece el waypoint inicial en la posición actual del enemigo
        waypointIndex = ClosestWaypoint();

        target = caminos.points[waypointIndex];

        // Obtener el Animator adjunto al GameObject
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Establecer el booleano en el Animator
        animator.SetBool("EstaEnCombate", esta_en_combate);
        if (!esta_en_combate)
        {
            Mover();
        }
        if (esta_en_combate == true && aliado != null)
        {
            // Accede a la variable dps del aliado
            recibirDano(aliado.dps);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            esta_en_combate = true;
            // Obtiene una referencia al objeto del aliado
            aliado = collision.gameObject.GetComponent<Aliado_stats>();
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
            esta_en_combate = false;
        }
    }

    private void Mover()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * velocidad * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
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
    //==============================================================================================
    private void recibirDano(float dano)
    {
        if (esta_en_combate == true)
        {
            vida -= dano * Time.deltaTime;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (vida <= 0 || dano > vida_maxima)
        {
            Morir();
        }
    }


    int GenerateRandomNumber()
    {
        // Genera un número aleatorio entre 0 (inclusive) y 1 (exclusivo)
        float randomNumber = Random.value;

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
        float randomNumber = Random.value;

        // Si el número generado es menor o igual a 0.2, devuelve verdadero; de lo contrario, devuelve falso
        return randomNumber <= 0.4f;
    }

    public void Morir()
    {
        Destroy(gameObject); // Destruye el enemigo
        Instantiate(particulasMuerte, transform.position, Quaternion.identity);

        if (DropCarta())
        {
            cartaAleatoria();
        }
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

}
