using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverScene;
    
    void Start()
    {
        //Setea la variable gameOver false y el tiempo de inicio de juego en 1
        gameOver = false;
        Time.timeScale = 1;
        
    }


    // Update is called once per frame
    void Update()
    {
        //Verifica si el juego ha terminado
        if (gameOver)
        {
            //Detiene el tiempo del juego
            Time.timeScale = 0;
            //Activa la escena 
            gameOverScene.SetActive(true);
            
            
        }
       
    }
}
