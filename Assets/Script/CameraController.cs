using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objetivo;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - objetivo.position;
    }

    
    void Update()
    {

        Vector3 nuevaPosicion = new Vector3(transform.position.x, transform.position.y, offset.z + objetivo.position.z);
        transform.position = nuevaPosicion;
    }
}
