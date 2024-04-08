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

    bool encimaCasilla=false;

    void Start(){
        gameCanvas=GameObject.FindWithTag("CanvasCartas");
        panelCanvas=gameCanvas.GetComponent<Canvas>();
    }

    void Update(){
        if (colocandoPersoanje && Input.GetMouseButtonDown(0)) // Verificar si se ha hecho clic
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Lanzar un rayo desde la posición del ratón
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~LayerMask.GetMask("Personaje")))
            {
                if (hit.transform.CompareTag("Casilla")) // Verificar si se ha hecho clic en una casilla
                {
                    Debug.Log("Clic en la casilla");

                    // Colocar el personaje en la casilla
                    if (character != null)
                    {
                        character = GameObject.FindGameObjectWithTag("Personaje");
                        Movimiento_Aliodos characterScript = character.GetComponent<Movimiento_Aliodos>();
                        if (characterScript != null) {
                            characterScript.colocado=true;
                        }
                                    
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
    /*
    private void OnMouseDown(){
  
        if(colocandoPersoanje==true && encimaCasilla){
            character = GameObject.FindGameObjectWithTag("Personaje");
            Movimiento_Aliodos characterScript = character.GetComponent<Movimiento_Aliodos>();
            if (characterScript != null) {
                characterScript.colocado=true;
            }
                        
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
*/


}

        
        
    

