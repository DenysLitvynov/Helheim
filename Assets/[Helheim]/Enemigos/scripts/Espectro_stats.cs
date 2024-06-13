﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espectro_Stats : MonoBehaviour
{
    private Movimiento_Enemigo combate;
    public float vida_maxima = 100f;//La vida maxima del enemigo, solo para comparar y saber si se muere de una vez
    public float vida = 100f; // La vida del enemigo
    public float daсo_espectro = 50f;//daсo que causa el enemigo(el aliado tomara esto como parametro en recibirDaсo())
    private Aliado_stats aliado;
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
            aliado = collision.gameObject.GetComponent<Aliado_stats>();
            muro = collision.gameObject.GetComponent<aliado_muro>();
            flecha= collision.gameObject.GetComponent<Movimento_Frecha>();
            Mjolnir = collision.gameObject.GetComponent<MjolnirController>();

            if (aliado != null )
            {
                // Hace daño al aliado
                aliado.vida -= daсo_espectro; // Elimina la multiplicación por Time.deltaTime
                // Destruye el espectro
                Destroy(gameObject);
                audioSource.PlayOneShot(EfectosDesonido[1]);
            }else if(muro != null){
                 // Hace daño al aliado
                muro.vida -= daсo_espectro; // Elimina la multiplicación por Time.deltaTime
                // Destruye el espectro
                Destroy(gameObject);
                audioSource.PlayOneShot(EfectosDesonido[1]);
            }else if(flecha != null){
                Destroy(collision.gameObject);
                Destroy(gameObject);
                audioSource.PlayOneShot(EfectosDesonido[1]);
            }
            else if (Mjolnir != null)
            {
                //Destroy(collision.gameObject);
                Destroy(gameObject);
                audioSource.PlayOneShot(EfectosDesonido[1]);
            }
            if (DropCarta()){
                cartaAleatoria();
            }
        }
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