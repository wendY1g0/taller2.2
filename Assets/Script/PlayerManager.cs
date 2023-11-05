using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverScene;
    public Text puntaje;
    public static int cantPuntaje;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        cantPuntaje = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            //Detiene el juego
            Time.timeScale = 0;
            gameOverScene.SetActive(true);
        }
        puntaje.text = "Puntaje: " +cantPuntaje;
    }
}
