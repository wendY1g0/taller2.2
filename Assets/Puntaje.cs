using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;


    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        //Aumenta los puntos de acuerdo al tiempo transcurrido
        puntos += Time.deltaTime;
        //Actualiza el texto
        textMesh.text = puntos.ToString("0");
    }
}
