using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class salto : MonoBehaviour
{
    private Vector3 coordenadas = new Vector3(22.9099998f, 4.38000011f, -0.0799999982f);
    private Enemigo_stats boss;
    public GameObject Brazos;

    public GameObject Brazos2;

    public GameObject Brazos3;


    void Start()
    {
        boss = GetComponent<Enemigo_stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.vida >= 124.70 && boss.vida <= 125) {
            boss.dano_enemigo = 40f;

            Brazos.SetActive(false);
            Brazos2.SetActive(true);
            Brazos3.SetActive(false);

            Debug.Log("Vida al 50");

        } else if (boss.vida >= 59.75 && boss.vida <= 60) {
            boss.dano_enemigo = 80f;

            Brazos.SetActive(false);
            Brazos2.SetActive(false);
            Brazos3.SetActive(true);

            Debug.Log("Vida al 25");
        }
    }
}
