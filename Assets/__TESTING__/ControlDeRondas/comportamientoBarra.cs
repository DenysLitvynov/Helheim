using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {
  
    public UnityEngine.UI.Image vida;

    public float vidaActual = 100f;

    private void OnCollisionEnter(Collision other){
        
        if(other.gameObject.tag== "enemigo1" || other.gameObject.tag== "enemigo2" || other.gameObject.tag== "enemigo3" || other.gameObject.tag == "Enemy")
        {

            Debug.Log("Hola perra");

            vidaActual -= 25f;

            
            vida.fillAmount = vidaActual/100f;

            Destroy(other.gameObject);

        }

    }

}
