using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Berserk : MonoBehaviour
{
    public float velocidad = 5f;
    public bool esta_en_combate = false;
    public bool colocado = false;
    public ParticleSystem spawn;
    private GameObject aliadoIdentificado;
    private bool spawnEffectInstanciado = false;

    // Offset fijo para la posición Y
    private float fixedYOffset = 0.15f; // Ajusta este valor según sea necesario

    private void Update()
    {
        if (!esta_en_combate && colocado)
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }

        if (esta_en_combate && aliadoIdentificado == null)
        {
            // Establece que el jefe ya no está en combate.
            esta_en_combate = false;
        }

        if (colocado && !spawnEffectInstanciado)
        {
            // Usa la posición del transform y ajusta solo el eje Y
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + fixedYOffset, transform.position.z);
            // Ajuste de rotación para que el sistema de partículas mire hacia arriba
            Quaternion rotation = Quaternion.Euler(-90, 0, 0);
            ParticleSystem effectInstance = Instantiate(spawn, spawnPosition, rotation);
            spawnEffectInstanciado = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            esta_en_combate = true;
            aliadoIdentificado = collision.gameObject;
        }
        else if (collision.gameObject.tag == "Entorno")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            aliadoIdentificado = null;
            esta_en_combate = false;
        }
    }
}

