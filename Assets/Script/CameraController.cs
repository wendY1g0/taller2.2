using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Referencia el objeto al que la camara seguira 
    public Transform objetivo;
    //Distancia entre la camara y el objetivo
    private Vector3 offset;

    void Start()
    {
        //Calcula la distancia entre el objetivo y la camara
        offset = transform.position - objetivo.position;
    }

    
    void Update()
    {
        //Crea la nueva posicion de la camara manteniendo la misma altura
        Vector3 nuevaPosicion = new Vector3(transform.position.x, transform.position.y, offset.z + objetivo.position.z);
        //Asigna la nueva posicion a la camara
        transform.position = nuevaPosicion;
    }
}
