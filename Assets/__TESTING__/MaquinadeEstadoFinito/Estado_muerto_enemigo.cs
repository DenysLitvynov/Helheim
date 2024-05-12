using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado_muerto_enemigo : Estado_Base_Enemigo
{
    public CharacterCardManager cartas;
    public CharacterCardScriptableObject martillo;
    public CharacterCardScriptableObject berserk;

    public override void EnterState(Controlador_de_Estados enemigo)
    {
        Debug.Log("HOLA  DESDE EL ESTADO MUERTO");
        enemigo.destruir();
        GameObject characterManagerObject = GameObject.Find("Game Manager");
        cartas = characterManagerObject.GetComponent<CharacterCardManager>();
        berserk= Resources.Load<CharacterCardScriptableObject>("Berserk");
        martillo = Resources.Load<CharacterCardScriptableObject>("Mjolnir");

        if (DropCarta())
        {
            cartaAleatoria();
        }

    }

    public override void UpdateState(Controlador_de_Estados enemigo) {}

    public override void OnCollisionEnter(Controlador_de_Estados enemigo, Collision collision){}

    //----------------------------------------------------------------------------
    //DROPEO DE CARTAS
    //----------------------------------------------------------------------------
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
}
