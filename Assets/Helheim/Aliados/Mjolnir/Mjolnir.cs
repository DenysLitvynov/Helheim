using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mjolnir : MonoBehaviour
{

    private bool destruccionhabilitada=true;

    public GameObject modelomartillo;
    public void EfectoMartillo(Vector3 posicionmartillo)
    {
        GameObject.Instantiate(modelomartillo,posicionmartillo,Quaternion.identity,transform);

        Autodestruccion();
         
    }

    private void OnTriggerEnter(Collider other)
    {

        if (destruccionhabilitada)
        {
            if (other.CompareTag("Enemigo"))
            {
                Debug.Log("Enemigo destruido");

                Destroy(other.gameObject);
            }
        }
    }

    private void Autodestruccion()
    {

        Destroy(this,5);

    }

}
