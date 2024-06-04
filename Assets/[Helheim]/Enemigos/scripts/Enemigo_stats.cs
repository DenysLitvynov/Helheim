using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemigo_stats : MonoBehaviour
{
    private Movimiento_Enemigo combate;
    public float vida_maxima = 100f;//La vida maxima del enemigo, solo para comparar y saber si se muere de una vez
    public float vida = 100f; // La vida del enemigo
    public float dano_enemigo = 15f;//da�o que causa el enemigo(el aliado tomara esto como parametro en recibirDa�o())
    private Aliado_stats aliado;
    private Movimento_Frecha frecha;
    public CharacterCardManager cartas;
    public ParticleSystem particulasMuerte;

    public CharacterCardScriptableObject martillo;
    public CharacterCardScriptableObject berserk;

    private void Start()
    {
        vida = vida_maxima;
        GameObject characterManagerObject = GameObject.Find("Game Manager");
        combate = GetComponent<Movimiento_Enemigo>();
        cartas = characterManagerObject.GetComponent<CharacterCardManager>();
    }

    private void Update()
    {
        if (combate.esta_en_combate == true && aliado != null)
        {
            // Accede a la variable dps del aliado
            recibirDano(aliado.dps);
        }
    }

    private void recibirDano(float dano)
    {
        if (combate.esta_en_combate == true)
        {
            vida -= dano * Time.deltaTime;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (vida <= 0 || dano > vida_maxima) 
        {
            if(DropCarta()){
                cartaAleatoria();
            }
            Morir();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Aliado")
        {
            combate.esta_en_combate = true;
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
            combate.esta_en_combate = false;
        }
    }

    public void cartaAleatoria(){
        if(cartas.amtOfCards<10){
            cartas.amtOfCards++;
            
            if(GenerateRandomNumber()==1){
                cartas.characterCardSO[cartas.amtOfCards-1]=martillo;
            }else{
                cartas.characterCardSO[cartas.amtOfCards-1]=berserk;
            }

            cartas.characterCards = new GameObject[cartas.amtOfCards];
            cartas.AddCharacterCard(cartas.amtOfCards-1);
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
        return randomNumber <= 0.2f;
    }
    public void Morir()
    {
        Destroy(gameObject); // Destruye el enemigo
                             // Define un desplazamiento en el eje Y
        Vector3 posicion = transform.position + new Vector3(0, 1.0f, 0); // Ajusta el valor 1.0f según sea necesario
        Instantiate(particulasMuerte, posicion, Quaternion.identity);
    }

}
