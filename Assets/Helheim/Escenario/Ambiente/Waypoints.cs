using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public  Transform[] points;//Usamos transform cuando queremos un lista de Gameobject

    private void Awake()
    {
        //childcount es el conteo de hijos que tiene un objeto
        points = new Transform[transform.childCount];//En nuestro caso tenemos 17puntos.
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}

