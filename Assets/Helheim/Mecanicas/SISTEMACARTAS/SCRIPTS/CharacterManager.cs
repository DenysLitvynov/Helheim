using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class CharacterManager : MonoBehaviour,IPointerClickHandler
{

    public GameObject panelCanvas;
    public GameObject characterPrefab;
    public Sprite levelCard;

    GameObject character;
    public bool colocandoPersonaje=false;
    public float tiempoEspera; // Tiempo que debe pasar antes de poder colocar otro personaje
    private float tiempoUltimaColocacion = Mathf.NegativeInfinity; // Inicializamos el tiempo de la última colocación con un valor muy pequeñodo haces click a una carta
    public string nombre;

    public CharacterCardManager cartas;
    
   private void Start()
    {
        GameObject characterManagerObject = GameObject.Find("Game Manager");
        cartas = characterManagerObject.GetComponent<CharacterCardManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (Time.time - tiempoUltimaColocacion >= tiempoEspera || tiempoUltimaColocacion == Mathf.NegativeInfinity)
        {
            
            //Sirve para saber si se esta colocando un personaje o no;
            colocandoPersonaje=true;
            //Desactiva el canvas
            panelCanvas=GameObject.FindWithTag("CanvasCartas");
            panelCanvas.SetActive(false);

            foreach(SlotsManagerCollider slots in GameObject.FindObjectsOfType<SlotsManagerCollider>()){
                slots.colocandoPersoanje=true;
                slots.tiempoPasado=Time.time;
            }
            //Crea el personaje
            
            character = Instantiate(characterPrefab, new Vector3(0, 0, -1) ,Quaternion.Euler(0,180,0));  
            character.GetComponent<MeshRenderer>();
            // Actualiza el tiempo de la última colocación
            tiempoUltimaColocacion = Time.time;

            //Un 10% de probabilidades de mejorar la carta
            if(randomNumber()){
                MejorarCarta(nombre);
            }
            
  
        }else{
            Debug.Log("La carta esta en cooldown");
        }

    } 

    void MejorarCarta(string nombreCarta){
        CharacterCardScriptableObject prefab ;
        if(levelCard.name=="LVL1"){
            prefab = Resources.Load<CharacterCardScriptableObject>(nombreCarta+"/"+nombreCarta+"LVL2");
        }else{
            prefab = Resources.Load<CharacterCardScriptableObject>(nombreCarta+"/"+nombreCarta+"LVL3");
        }
        this.characterPrefab=prefab.characterSprite;
        this.levelCard=prefab.levelCard;
        this.tiempoEspera=prefab.cooldown;
        
        GetComponent<Image>().sprite= this.levelCard;
        //GetComponentInChildren<RawImage>().texture = this.characterPrefab;
        //cartas.characterCards = new GameObject[cartas.amtOfCards];
           
    }

    bool randomNumber()
    {
        // Genera un nmero aleatorio entre 0 (inclusive) y 1 (exclusivo)
        float randomNumber = Random.value;

        // Si el nmero generado es menor o igual a 0.1 (10%), devuelve verdadero; de lo contrario, devuelve falso
        return randomNumber <= 0.5f;
    }
    
   
}
