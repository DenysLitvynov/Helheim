using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class CharacterManager : MonoBehaviour,IPointerClickHandler
{

    public GameObject panelCanvas;
    public GameObject characterPrefab;
    GameObject character;
    public bool colocandoPersonaje=false;
    public float tiempoEspera; // Tiempo que debe pasar antes de poder colocar otro personaje
    private float tiempoUltimaColocacion = Mathf.NegativeInfinity; // Inicializamos el tiempo de la última colocación con un valor muy pequeñodo haces click a una carta
    
   
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
        
        }else{
            Debug.Log("La carta esta en cooldown");
        }

    } 

   

   
}
