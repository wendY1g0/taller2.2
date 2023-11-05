using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piso : MonoBehaviour
{
    public GameObject[] prefab;
    public float spawnZ = 0;
    public float largo= 10;
    public int pisos = 15;
    private List<GameObject> pisosActivos = new List<GameObject>();

    public Transform jugador;
    void Start()   
    {
        Spawn(0);
      for(int i = 0; i < pisos; i++)
      {
            Spawn(Random.Range(0, prefab.Length));
      }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jugador.position.z - 15 > spawnZ - (pisos * largo))
        {
            Spawn(Random.Range(0, prefab.Length));
            borrarCamino();
        }
    }
    public void Spawn(int pisoIndice)
    {

        GameObject gameObject= Instantiate(prefab[pisoIndice], transform.forward * spawnZ, transform.rotation);
        pisosActivos.Add(gameObject);
        spawnZ = spawnZ + largo;
    }
    public void borrarCamino()
    {
        Destroy(pisosActivos[0]);
        pisosActivos.RemoveAt(0);
    }
}
