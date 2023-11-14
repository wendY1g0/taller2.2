using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    private CharacterController controlador;
    private Vector3 direccion;
    public float forwardSpeed;
    //Velocidad que se aumentara por segundo a la velocidad inicial 
    public float velocidadIncremento = 0.1f;

    //Variables movimientos laterales
    private int pista = 1; //0:izquierda 1:medio 2:derecha
    public float DistanciaPistas = 4; //Distancia entre las pistas

    //Variables salto
    public float fuerzaSalto = 8;
    public float gravedad = -20;

    //Variables sonido
    public AudioSource musicaFondo;
    public AudioClip sonidoSalto;
    



    private void Start()
    {
        controlador = GetComponent<CharacterController>();
        direccion.z = forwardSpeed;
        musicaFondo.Play();
       
    }

    private void Update()
    {
        //La direccion en "z" aumentara al ser multiplicada por la velocidad de incremento
        direccion.z += velocidadIncremento * Time.deltaTime;
        direccion.y += gravedad * Time.deltaTime;
        //Si se presiona la tecla espacio, se produce el salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Componente IsGrounded es parte del Character controller, si el jugador esta en el piso, se podra saltar, de otra manera no se podra 
            if (controlador.isGrounded)
            {
            salto();
            }
        }

        //Si se presiona una tecla el valor de la pista cambiara, como tambien la posicion de el jugador
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pista++;
            if (pista == 3)
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
        }
        else if (pista == 2)
        {
            posicionActual += Vector3.right * DistanciaPistas;
        }
        transform.position = posicionActual;
        controlador.center = controlador.center;


    }
    private void FixedUpdate()
    {
        controlador.Move(direccion * Time.fixedDeltaTime);
       
    }

    private void salto()
    {
        
        direccion.y = fuerzaSalto;
        if(sonidoSalto != null)
        {
            musicaFondo.PlayOneShot(sonidoSalto);
        }
       

    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstaculo")
        {
            
            PlayerManager.gameOver = true;
            //Se detiene la musica de fondo y el clip de sonido de salto es null, para que esta no pueda ser accedido
            
            musicaFondo.Stop();
            sonidoSalto = null;
           
        }
    }

}
