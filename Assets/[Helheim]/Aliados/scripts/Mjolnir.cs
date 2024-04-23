using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mjolnir : MonoBehaviour
{

    private bool destruccionhabilitada=true;

    public List<BoxCollider> areadetecciones= new List<BoxCollider>();
     
        public GameObject modelomartillo;

    public float danomartillo = 100f;
    private void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            ActivarEfecto();

            Autodestruccion();
        }
    }

    public void ActivarEfecto()
    {
        foreach(BoxCollider collider in areadetecciones)
        {
            collider.enabled = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (destruccionhabilitada)
        {
            if (other.CompareTag("Enemigo"))
            {
                

                Enemigo_stats enemigo = other.GetComponent<Enemigo_stats>();

                if(enemigo != null)
                {
                    enemigo.vida -= danomartillo;

                    if (enemigo.vida <= 0)
                    {
                        Destroy(other.gameObject);

                        Debug.Log("Enemigo matado");

                    }
                    else
                    {

                        Debug.Log( "Enemigo dañado,vida restante " + enemigo.vida.ToString());
                    }
                }
            }
        }
    }

    private void Autodestruccion()
    {

        Destroy(modelomartillo,2);

    }

}
