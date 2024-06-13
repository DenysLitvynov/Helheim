using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class Espectro_Stats : MonoBehaviour
{
    private Movimiento_Enemigo combate;

    public float daсo_espectro = 50f;//daсo que causa el enemigo(el aliado tomara esto como parametro en recibirDaсo())
    private Aliado aliado;
    private aliado_muro muro;
    private Movimento_Frecha flecha;
    public MjolnirController Mjolnir;
    public CharacterCardManager cartas;
    

    public CharacterCardScriptableObject martillo;
    public CharacterCardScriptableObject berserk;

   [Header("-----------------FX Y SFX-----------------")]
    public ParticleSystem particulasMuerte;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] EfectosDesonido;


    private void Start()
    {
        audioSource.PlayOneShot(EfectosDesonido[0]);
        combate = GetComponent<Movimiento_Enemigo>();

        GameObject characterManagerObject = GameObject.Find("Game Manager");
        combate = GetComponent<Movimiento_Enemigo>();
        cartas = characterManagerObject.GetComponent<CharacterCardManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado" ||collision.gameObject.tag == "Flecha" )
        {
            // Obtiene una referencia al objeto del aliado
            aliado = collision.gameObject.GetComponent<Aliado>();
            muro = collision.gameObject.GetComponent<aliado_muro>();
            flecha= collision.gameObject.GetComponent<Movimento_Frecha>();
            Mjolnir = collision.gameObject.GetComponent<MjolnirController>();
            Debug.Log("Hello: ");
            if (aliado != null )
            {
                 
                // Hace daño al aliado
                aliado.vida -= daсo_espectro; // Elimina la multiplicación por Time.deltaTime
                // Destruye el espectro
                StartCoroutine(Die());
            }else if(muro != null){
                 // Hace daño al aliado
                muro.vida -= daсo_espectro; // Elimina la multiplicación por Time.deltaTime
                // Destruye el espectro
                StartCoroutine(Die());
            }else if(flecha != null){
                Destroy(collision.gameObject);
                StartCoroutine(Die());
            }
            else if (Mjolnir != null)
            {
                //Destroy(collision.gameObject);
                StartCoroutine(Die());
            }
            if (DropCarta()){
                cartaAleatoria();
            }
        }
    }
    IEnumerator Die(){
    
    audioSource.PlayOneShot(EfectosDesonido[1]);
    yield return new WaitForSeconds(1); //waits 3 seconds
    Destroy(gameObject); //this will work after 3 seconds.
}


    public void cartaAleatoria(){
        
        cartas.amtOfCards++;
        
        if(GenerateRandomNumber()==1){
            cartas.characterCardSO[cartas.amtOfCards-1]=martillo;
        }else{
            cartas.characterCardSO[cartas.amtOfCards-1]=berserk;
        }

        cartas.characterCards = new GameObject[cartas.amtOfCards];
        cartas.AddCharacterCard(cartas.amtOfCards-1);
        
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
        return randomNumber <= 0.2f;
    }
}