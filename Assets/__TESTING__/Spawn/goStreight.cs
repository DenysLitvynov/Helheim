using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f; // Velocità dell'oggetto

    void Start()
    {
        // Avvia il movimento dell'oggetto quando la scena viene attivata
        MoveStraight();
    }

    void MoveStraight()
    {
        // Muove l'oggetto nella direzione forward alla velocità specificata
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
