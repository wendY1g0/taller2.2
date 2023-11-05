using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private CharacterController controlador;
    private Vector3 direccion;
    public float forwardSpeed;

    //Movimientos laterales

    private int pista = 1; //0:izquierda 1:medio 2:derecha
    public float DistanciaPistas = 4; //Distancia entre las pistas

    private void Start()
    {
        controlador = GetComponent<CharacterController>();

    }

    private void Update()
    {
        direccion.z = forwardSpeed;

        //Si se presiona una tecla el valor de la pista cambiara
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pista++;
            if(pista == 3)
            {
                pista = 2; 
            }
        }
        //El mismo caso aplica para la pista izquierda, pero en este caso se restara
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pista--;
            if (pista == -1)
            {
                pista = 0;
            }
        }

        //Para calcular la pista donde nos encontramos

        Vector3 posicionActual = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (pista == 0)
        {
            posicionActual += Vector3.left * DistanciaPistas;
        }else if (pista == 2)
        {
            posicionActual += Vector3.right * DistanciaPistas;
        }
        transform.position = posicionActual;


    }
    private void FixedUpdate()
    {
        controlador.Move(direccion * Time.fixedDeltaTime);
    }
    
}
