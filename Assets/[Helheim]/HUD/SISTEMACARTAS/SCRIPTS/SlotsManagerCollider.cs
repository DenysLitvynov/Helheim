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
    public GameObject slotActual = null;
    public GameObject characterMov;
    

    void Start(){
        gameCanvas=GameObject.FindWithTag("CanvasCartas");
        panelCanvas=gameCanvas.GetComponent<Canvas>();
    }

    void Update()
    {
        // Verificar si se ha presionado cualquier tecla y si se está en modo de colocación
        if (Input.anyKeyDown && colocandoPersoanje)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                character = GameObject.FindGameObjectWithTag("Personaje");
                Destroy(character);
                foreach (SlotsManagerCollider slots in GameObject.FindObjectsOfType<SlotsManagerCollider>())
                {
                    slots.colocandoPersoanje = false;
                    slots.slotActual = null;
                }

            }
            else
            {
                TryPlaceCharacter();
            }
            
        }
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
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Personaje" ){
            CharacterCardManager.casillaActual = this.gameObject;
        }
    }

    void OnCollisionExit(Collision collision){
        if (collision.gameObject.tag == "Aliado" && collision.gameObject.layer == LayerMask.NameToLayer("Corredores"))
        {
            VaciarCasilla();
        }
    }
    
     void TryPlaceCharacter(){
  
        if(colocandoPersoanje==true ){
            character = GameObject.FindGameObjectWithTag("Personaje");
            Movimiento_Aliodos characterScript = character.GetComponent<Movimiento_Aliodos>();
           
            Movimiento_Berserk berserkerScript = character.GetComponent<Movimiento_Berserk>();
            
            SpawnArrow spawnScript = character.GetComponentInChildren<SpawnArrow>();

            if (characterScript != null) {
                characterScript.colocado=true;
            }else if(spawnScript!=null){
                spawnScript.colocado=true;
            }else if(berserkerScript!=null){
                berserkerScript.colocado=true;
            }
                        
            character.tag="Aliado";
            
            if (CharacterCardManager.casillaActual!=null)
            {
                character.transform.SetParent(CharacterCardManager.casillaActual.transform);
                Vector3 pos = new Vector3(0, 0, -1);
                character.transform.localPosition = pos;
            } 
           
            
            gameCanvas.SetActive(true);
            foreach(SlotsManagerCollider slots in GameObject.FindObjectsOfType<SlotsManagerCollider>()){
                slots.colocandoPersoanje=false;
                slots.slotActual=null;
            }
        }
    }
    
    void VaciarCasilla(){
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            //Destroy(transform.GetChild(i).gameObject);
            character.transform.SetParent(character.transform.parent.parent);
        }
    }


}