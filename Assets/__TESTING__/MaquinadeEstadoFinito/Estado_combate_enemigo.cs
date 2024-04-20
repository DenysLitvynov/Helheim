using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Estado_combate_enemigo : Estado_Base_Enemigo
{
    

    public float vida;
    public float vidaMaxima;
    public float dano_recibido;
    private bool enCombate;

    //COSAS DE ALIADOS
    private Aliado_stats aliado;
    private Movimento_Frecha frecha;

    public override void EnterState(Controlador_de_Estados enemigo)
    {
        Debug.Log("HOLA DESDE EL ESTADO COMBATE");
        ///GameObject characterManagerObject = GameObject.Find("Game Manager");
        //cartas = characterManagerObject.GetComponent<CharacterCardManager>();

    }

    public override void UpdateState(Controlador_de_Estados enemigo)
    {
        if (aliado == null)
        {
            enemigo.CambiarEstado(enemigo.estadoMovimiento);
        }
        else
        {
            dano_recibido = aliado.dps;
            vida -= dano_recibido * Time.deltaTime;
            Debug.Log("DAÑO RECIBIDO : " + dano_recibido);

            if (vida <= 0 || dano_recibido >= vidaMaxima)
            {
                enemigo.CambiarEstado(enemigo.estadoMuerto);
            }
        }
    }




    public override void OnCollisionEnter(Controlador_de_Estados enemigo, Collision collision)
    {
        if (collision.gameObject.CompareTag("Aliado"))
        {
            frecha = collision.gameObject.GetComponent<Movimento_Frecha>();
            // Obtiene una referencia al objeto del aliado
            aliado = collision.gameObject.GetComponent<Aliado_stats>();
        }
    }

}
    //----------------------------------------------------------------------------
    //DROPEO DE CARTAS
    //----------------------------------------------------------------------------
    /*
    public void cartaAleatoria()
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
    */


