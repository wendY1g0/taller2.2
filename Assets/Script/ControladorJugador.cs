using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    //Componente oara controlar el dinosaurio
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
    


    //Metodo de inicio del juego
    private void Start()
    {
        //Obtiene el componente CharacterController del objeto
        controlador = GetComponent<CharacterController>();
        direccion.z = forwardSpeed;
        musicaFondo.Play();
       
    }

    private void Update()
    {
        //La direccion en "z" aumentara al ser multiplicada por la velocidad de incremento
        direccion.z += velocidadIncremento * Time.deltaTime;
        //Le da la gravedad al dinosaurio
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
        //El mismo caso aplica para la pista izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pista--;
            if (pista == -1)
            {
                pista = 0;
            }
        }

        //Para calcular la posicion actual del dinosaurio en la pista
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
        //Actualiza el centro
        controlador.center = controlador.center;


    }
    //Se utiliza FixedUpdate para tener una mejor consistencia en el comportamiento, ya que en este caso se realizan cambios fisicos de manera regular  
    private void FixedUpdate()
    {
        controlador.Move(direccion * Time.fixedDeltaTime);
       
    }

    //Metodo para el salto
    private void salto()
    {
        
        direccion.y = fuerzaSalto;
        //Metodo para el sonido que se reproduce al saltar
        if(sonidoSalto != null)
        {
            //PlayOneShot solo lo reproduce 1 vez
            musicaFondo.PlayOneShot(sonidoSalto);
        }
       

    }

    //Metodo utilizado cuando el jugador choca contra un collider
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Si el tag de el objeto es obstaculo, el juego se detendra automaticamente, desplegando una pantalla game over 
        if(hit.transform.tag == "Obstaculo")
        {
            //Setea el PlayerManager a true, para asi desplegar la pantalla de perdida
            PlayerManager.gameOver = true;
            //Se detiene la musica de fondo y el clip de sonido de salto es null, para que esta no pueda ser accedido
            musicaFondo.Stop();
            sonidoSalto = null;
           
        }
    }

}
