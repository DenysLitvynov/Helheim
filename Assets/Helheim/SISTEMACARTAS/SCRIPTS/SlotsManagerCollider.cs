using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotsManagerCollider : MonoBehaviour
{
    public float tiempoPasado;
    public GameObject character;
    public bool colocandoPersoanje=false;
    //public CharacterManager carta;
    Canvas panelCanvas;
    GameObject gameCanvas;
    void Start(){
        gameCanvas=GameObject.FindWithTag("CanvasCartas");
        panelCanvas=gameCanvas.GetComponent<Canvas>();
    }

    private void OnMouseOver(){
        
        //if(character == null ){
            if(GameObject.FindGameObjectWithTag("Personaje") != null && this.transform.childCount==0 ){
                character = GameObject.FindGameObjectWithTag("Personaje");
                character.transform.SetParent(this.transform);
               
                Vector3 pos=new Vector3(0, 0, -1);
                character.transform.localPosition = pos;
                
            }
        //} 
    }
    
    private void OnMouseDown(){
        if(colocandoPersoanje==true){
                character = GameObject.FindGameObjectWithTag("Personaje");
                character.tag="Aliado";
                character.transform.SetParent(this.transform);
               
                Vector3 pos=new Vector3(0, 0, -1);
                character.transform.localPosition = pos;
                gameCanvas.SetActive(true);
                foreach(SlotsManagerCollider slots in GameObject.FindObjectsOfType<SlotsManagerCollider>()){
                    slots.colocandoPersoanje=false;
                }
       }
    }
}
