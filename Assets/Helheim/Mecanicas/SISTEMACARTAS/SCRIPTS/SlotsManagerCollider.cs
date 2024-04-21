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
    GameObject slotActual = null;

    

    void Start(){
        gameCanvas=GameObject.FindWithTag("CanvasCartas");
        panelCanvas=gameCanvas.GetComponent<Canvas>();
    }

    void Update()
    {
        // Verificar si se ha presionado cualquier tecla y si se está en modo de colocación
        if (Input.anyKeyDown && colocandoPersoanje)
        {
            TryPlaceCharacter();
        }
    }

   

    private void OnMouseOver(){
        
        //if(character == null ){
            if(GameObject.FindGameObjectWithTag("Personaje") != null && this.transform.childCount==0 ){
                character = GameObject.FindGameObjectWithTag("Personaje");
                character.transform.SetParent(this.transform);
               
                Vector3 pos=new Vector3(0, 0, -1);
                character.transform.localPosition = pos;

            if (colocandoPersoanje)
            {
                slotActual = this.gameObject;
            }
            else
            {
                slotActual = null;
            }

        }
        //} 
    }
    
     void TryPlaceCharacter(){
  
        if(colocandoPersoanje==true){
            character = GameObject.FindGameObjectWithTag("Personaje");
            Movimiento_Aliodos characterScript = character.GetComponent<Movimiento_Aliodos>();
            SpawnArrow spawnScript = character.GetComponent<SpawnArrow>();
            if (characterScript != null) {
                characterScript.colocado=true;
            }else if(spawnScript!=null){
                spawnScript.colocado=true;
            }
                        
            character.tag="Aliado";
            if (slotActual!=null)
            {
                character.transform.SetParent(slotActual.transform);
                Vector3 pos = new Vector3(0, 0, -1);
                character.transform.localPosition = pos;
            }
           
            
            gameCanvas.SetActive(true);
            foreach(SlotsManagerCollider slots in GameObject.FindObjectsOfType<SlotsManagerCollider>()){
                slots.colocandoPersoanje=false;
            }
        }
    }



}