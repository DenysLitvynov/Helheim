using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3_vida : MonoBehaviour
{
    private Boss_Movimiento combate;
    public int health = 20; // La vida del enemigo

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
            health -= 1;
        }
        // Comprueba si la vida del enemigo ha llegado a 0
        if (health <= 0)
        {
            Destroy(gameObject); // Destruye el enemigo
        }
    }

}
    

