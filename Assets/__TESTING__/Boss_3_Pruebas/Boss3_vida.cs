using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_vida : MonoBehaviour
{
    private Boss_Movimiento combate;
    public float vida = 100f; // La vida del enemigo
    public float da�o_boss = 40f;

    private void Start()
    {
        combate = GetComponent<Boss_Movimiento>();
    }

    private void Update()
    {
        if (combate.esta_en_combate == true)
        {
            Vida_aliado_dummy aliado = GameObject.FindObjectOfType<Vida_aliado_dummy>();
            recibirDa�o(aliado.dps);
        }
    }

    private void recibirDa�o(float da�o)
    {
        if (combate.esta_en_combate==true)
        {
            vida -= da�o*Time.deltaTime;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye el enemigo
        }
    }

}
    

