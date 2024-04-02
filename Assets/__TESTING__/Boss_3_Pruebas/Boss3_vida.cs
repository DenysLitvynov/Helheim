using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_vida : MonoBehaviour
{
    private Boss_Movimiento combate;
    public float vida = 100f; // La vida del enemigo
    public float dps = 1f;

    private void Start()
    {
        combate = GetComponent<Boss_Movimiento>();
    }

    private void Update()
    {
        
        recibirDaño();
    }

    private void recibirDaño()
    {
        if (combate.esta_en_combate==true)
        {
            vida -= dps*Time.deltaTime;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye el enemigo
        }
    }

}
    

